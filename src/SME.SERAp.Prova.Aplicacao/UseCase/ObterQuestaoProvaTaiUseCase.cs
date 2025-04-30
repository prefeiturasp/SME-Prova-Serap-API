using MediatR;
using SME.SERAp.Prova.Aplicacao.Commands;
using SME.SERAp.Prova.Aplicacao.Queries;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoProvaTaiUseCase : AbstractUseCase, IObterQuestaoProvaTaiUseCase
    {
        public ObterQuestaoProvaTaiUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<QuestaoCompletaDto> Executar(long provaId)
        {
            var dadosAlunoLogado = await mediator.Send(new ObterDadosAlunoLogadoQuery());

            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, dadosAlunoLogado.Ra));
            if (provaStatus is not { Status: ProvaStatus.Iniciado })
                throw new NegocioException("Esta prova precisa ser iniciada.", 411);

            var dados = await mediator.Send(new ObterDetalhesAlunoCacheQuery(dadosAlunoLogado.Ra));
            var ultimaQuestao = await ObterUltimaQuestaoAdministrado(provaId, dados);

            if (ultimaQuestao == null)
            {
                //TODO: tratativa questao_aluno_tai
                var alunoDetalhes = await mediator.Send(new ObterAlunoDadosPorRaQuery(dadosAlunoLogado.Ra));
                var existeCadernoAluno = await mediator.Send(new ExisteCadernoAlunoPorProvaIdAlunoIdQuery(provaId, alunoDetalhes.AlunoId));
                var existeQuestaoAlunoTai = await mediator.Send(new ExisteQuestaoAlunoTaiPorAlunoIdQuery(provaId, alunoDetalhes.AlunoId));

                if (!existeCadernoAluno)
                {
                    await mediator.Send(new IncluirCadernoAlunoCommand(alunoDetalhes.AlunoId, provaId, "1"));
                }

                if (!existeQuestaoAlunoTai)
                {
                    await IncluirPrimeiraQuestaoAlunoTai(provaId, alunoDetalhes.AlunoId, "1");
                    //await Task.Delay(2000);
                }

                var resultadoRemocaoCache = await RemoverCaches(provaId, dadosAlunoLogado.Ra, alunoDetalhes.AlunoId);
                if (resultadoRemocaoCache)
                {
                    ultimaQuestao = await ObterUltimaQuestaoAdministrado(provaId, dados, false);
                }  

                if (ultimaQuestao == null)
                    throw new NegocioException("Última questão não localizada.");
            }

            var json = (await mediator.Send(new ObterQuestaoCompletaPorIdQuery(new[] { ultimaQuestao.Id }))).ToList();
            var jsonUltimaQuestao = json.FirstOrDefault();

            if (jsonUltimaQuestao == null)
                throw new NegocioException("Última questão não localizada (json).");

            var questaoCompleta = JsonSerializer.Deserialize<QuestaoCompletaDto>(jsonUltimaQuestao,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            questaoCompleta.Ordem = ultimaQuestao.Ordem;

            return questaoCompleta;
        }

        private async Task<QuestaoTaiDto> ObterUltimaQuestaoAdministrado(long provaId, MeusDadosRetornoDto dados, bool utilizarCache = true)
        {
            var questoesTaiAdministrado = await mediator.Send(new ObterQuestoesTaiAdministradoPorProvaAlunoQuery(provaId, dados.AlunoId, utilizarCache));
            return questoesTaiAdministrado?
                    .OrderBy(t => t.Ordem)?
                    .LastOrDefault();
        }

        private async Task IncluirPrimeiraQuestaoAlunoTai(long provaId, long alunoId, string caderno)
        {
            var idsQuestoes = (await mediator.Send(new ObterIdsQuestoesPorProvaIdCadernoQuery(provaId, caderno))).Distinct().ToList();
            var sortear = new Random();
            var questaoIdSorteada = idsQuestoes[sortear.Next(idsQuestoes.Count)];

            var questaoAlunoTai = new QuestaoAlunoTai(questaoIdSorteada, alunoId, 0);
            var questaoAlunoTaiId = await mediator.Send(new QuestaoAlunoTaiIncluirCommand(questaoAlunoTai));

            if (questaoAlunoTaiId <= 0)
                throw new NegocioException($"As questões TAI do aluno {alunoId} não foram inseridas.");
        }

        private async Task<bool> RemoverCaches(long provaId, long alunoRA, long alunoId)
        {
            await mediator.Send(new RemoverCacheCommand($"al-prova-{provaId}-{alunoRA}"));
            await mediator.Send(new RemoverCacheCommand($"al-q-administrado-tai-prova-{alunoId}-{provaId}"));
            return true;
        }
    }
}
