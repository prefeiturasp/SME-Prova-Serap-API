using MediatR;
using SME.SERAp.Prova.Aplicacao.Commands;
using SME.SERAp.Prova.Aplicacao.Queries;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
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
                    await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarCadernoAlunoProva, new
                    {
                        ProvaId = provaId,
                        AlunoId = alunoDetalhes.AlunoId,
                        Caderno = "1",
                    }));
                }

                if (!existeQuestaoAlunoTai)
                {
                    var novaQuestaoId = await IncluirPrimeiraQuestaoAlunoTai(provaId, alunoDetalhes.AlunoId, "1");
                    ultimaQuestao = new QuestaoTaiDto
                    {
                        Id = novaQuestaoId,
                        Ordem = 0
                    };
                    await SalvarPrimeiraQuestaoAdministradorCache(alunoDetalhes.AlunoId, provaId, ultimaQuestao);
                }
                else
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

        private async Task<long> IncluirPrimeiraQuestaoAlunoTai(long provaId, long alunoId, string caderno)
        {
            var idsQuestoes = (await mediator.Send(new ObterIdsQuestoesPorProvaIdCadernoQuery(provaId, caderno))).Distinct().ToList();
            var sortear = new Random();
            var questaoIdSorteada = idsQuestoes[sortear.Next(idsQuestoes.Count)];

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarOrdemQuestaoAlunoProvaTai, new
            {
                QuestaoId = questaoIdSorteada,
                alunoId,
                Ordem = 0
            }));
            return questaoIdSorteada;
        }

        private async Task SalvarPrimeiraQuestaoAdministradorCache(long alunoId, long provaId, QuestaoTaiDto novaQuestao)
        {
            var nomeChaveAlunoQuestaoAdministrado = CacheChave.ObterChave(CacheChave.QuestaoAdministradoTaiAluno, alunoId, provaId);
            var questoesAdministrado = new List<QuestaoTaiDto> { novaQuestao };
            await mediator.Send(new SalvarCacheCommand(nomeChaveAlunoQuestaoAdministrado, questoesAdministrado));
        }
    }
}