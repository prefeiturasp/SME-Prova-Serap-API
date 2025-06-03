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
            var dados = await mediator.Send(new ObterDetalhesAlunoCacheQuery(ra));

            var questoesTaiAdministrado = await mediator.Send(
                new ObterQuestoesTaiAdministradoPorProvaAlunoQuery(provaId, dados.AlunoId)
            );

            var ids = alunoRespostas
                .Where(t => t.AlternativaResposta.HasValue)
                .Select(t => t.QuestaoId)
                .ToArray();

            var jsons = await mediator.Send(new ObterQuestaoCompletaPorIdQuery(ids));

            var ordemPorQuestaoId = questoesTaiAdministrado
                .ToDictionary(q => q.Id, q => q.Ordem);

            var retornoTemp = new List<(ProvaTaiResultadoDto Resultado, int Ordem)>();

            foreach (var json in jsons)
            {
                var questaoCompleta = JsonSerializer.Deserialize<QuestaoCompletaDto>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var questao = questoesAluno.FirstOrDefault(t => t.Id == questaoCompleta.Id);
                var resposta = alunoRespostas.FirstOrDefault(t => t.QuestaoId == questaoCompleta.Id);
                var alternativa = await mediator.Send(
                    new ObterAlternativaPorIdQuery(resposta.AlternativaResposta.GetValueOrDefault()));

                if (questao != null && ordemPorQuestaoId.TryGetValue(questao.Id, out var ordem))
                {
                    retornoTemp.Add((
                        new ProvaTaiResultadoDto
                        {
                            DescricaoQuestao = questaoCompleta.Descricao,
                            OrdemQuestao = ordem + 1,
                            AlternativaAluno = alternativa?.Numeracao
                        },
                        ordem
                    ));
                }
            }

            return retornoTemp
                .OrderBy(t => t.Ordem)
                .Select(t => t.Resultado);
        }

    }
}
