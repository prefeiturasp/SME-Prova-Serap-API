using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaTaiResultadoResumoUseCase : IObterProvaTaiResultadoResumoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaTaiResultadoResumoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<ProvaTaiResultadoDto>> Executar(long provaId)
        {
            var ra = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var questoesAluno = await mediator.Send(new ObterQuestaoTaiPorProvaAlunoQuery(provaId, ra));
            var alunoRespostas = await mediator.Send(new ObterAlternativaAlunoRespostaQuery(provaId, ra));
            var criadoEm = await mediator.Send(new ObterQuestaoAlternativaComCriadoEmTaiQuery(provaId, ra));

            var criadoEmPorQuestao = criadoEm.ToDictionary(x => x.QuestaoId, x => x.CriadoEm);

            var ids = alunoRespostas.Where(t => t.AlternativaResposta.HasValue).Select(t => t.QuestaoId).ToArray();
            var jsons = await mediator.Send(new ObterQuestaoCompletaPorIdQuery(ids));

            var retornoTemp = new List<(ProvaTaiResultadoDto Resultado, DateTime CriadoEm)>();

            foreach (var json in jsons)
            {
                var questaoCompleta = JsonSerializer.Deserialize<QuestaoCompletaDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var questao = questoesAluno.FirstOrDefault(t => t.Id == questaoCompleta.Id);
                var resposta = alunoRespostas.FirstOrDefault(t => t.QuestaoId == questaoCompleta.Id);
                var alternativa = await mediator.Send(new ObterAlternativaPorIdQuery(resposta.AlternativaResposta.GetValueOrDefault()));

                if (questao != null && criadoEmPorQuestao.TryGetValue(questao.Id, out var dataCriado))
                {
                    retornoTemp.Add((
                        new ProvaTaiResultadoDto
                        {
                            DescricaoQuestao = questaoCompleta.Descricao,
                            OrdemQuestao = questao.Ordem,
                            AlternativaAluno = alternativa?.Numeracao
                        },
                        dataCriado
                    ));
                }
            }

            
            var ordem = 0;
            return retornoTemp
                .OrderBy(t => t.CriadoEm)
                .Select(t =>
                {
                    t.Resultado.OrdemQuestao = ++ordem;
                    return t.Resultado;
                });
        }
    }
}
