using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProximaQuestaoProvaTaiUseCase : AbstractUseCase, IObterProximaQuestaoProvaTaiUseCase
    {
        public ObterProximaQuestaoProvaTaiUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(long provaId, QuestaoAlunoRespostaSincronizarDto questaoAlunoRespostaSincronizarDto)
        {
            //-> dados da prova
            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));

            //-> dados do aluno 
            var aluno = await mediator.Send(new ObterDadosAlunoLogadoQuery());
            var dados = await mediator.Send(new ObterDetalhesAlunoCacheQuery(aluno.Ra));

            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, aluno.Ra));
            if (provaStatus == null || provaStatus.Status != ProvaStatus.Iniciado)
                throw new NegocioException($"Esta prova precisa ser iniciada.", 411);

            //-> obter ultima proficiencia do aluno
            var proficiencia = await mediator.Send(new ObterUltimaProficienciaPorProvaQuery(provaId, questaoAlunoRespostaSincronizarDto.AlunoRa));

            //-> obter itens da amostra do aluno
            var questoesAluno = await mediator.Send(new ObterQuestaoTaiPorProvaAlunoQuery(provaId, questaoAlunoRespostaSincronizarDto.AlunoRa));

            //-> obter itens respondidos do aluno
            var alunoRespostas = await mediator.Send(new ObterAlternativaAlunoRespostaQuery(provaId, questaoAlunoRespostaSincronizarDto.AlunoRa));

            //-> atualiza a resposta do aluno no cache.
            var alunoRespostasAtualizado = alunoRespostas.ToList();
            alunoRespostasAtualizado.Where(t => t.QuestaoId == questaoAlunoRespostaSincronizarDto.QuestaoId).FirstOrDefault().AlternativaResposta = questaoAlunoRespostaSincronizarDto.AlternativaId.GetValueOrDefault();

            questoesAluno = questoesAluno.OrderBy(t => t.Id);
            alunoRespostasAtualizado = alunoRespostasAtualizado.OrderBy(t => t.QuestaoId).ToList();

            var retorno = await mediator.Send(new ObterProximoItemApiRQuery(
                dados.AlunoId.ToString(),
                dados.Ano,
                proficiencia,
                questoesAluno.Select(t => t.Id).ToArray(),
                questoesAluno.Select(t => t.Discriminacao).ToArray(),
                questoesAluno.Select(t => t.ProporcaoAcertos).ToArray(),
                questoesAluno.Select(t => t.AcertoCasual).ToArray(),
                "", "", "", "",
                (int)prova.ProvaFormatoTaiItem,
                alunoRespostasAtualizado.Where(t => t.AlternativaResposta.HasValue).Select(t => t.AlternativaResposta.GetValueOrDefault()).ToArray(),
                alunoRespostasAtualizado.Where(t => t.AlternativaResposta.HasValue).Select(t => t.AlternativaCorreta).ToArray(),
                alunoRespostasAtualizado.Where(t => t.AlternativaResposta.HasValue).Select(t => t.QuestaoId).ToArray()
                )
            );

            //-> Se o id da questão retornado do tai não foi respondido continua a prova.
            var continuarProva = !alunoRespostas.Any(t => t.AlternativaResposta != null && t.QuestaoId == retorno.ProximaQuestao);

            await AtualizarDadosBanco(continuarProva, provaId, questaoAlunoRespostaSincronizarDto, prova, aluno, dados, retorno);

            await AtualizarDadosCache(continuarProva, provaId, aluno, questoesAluno, alunoRespostasAtualizado, retorno);

            if (!continuarProva)
            {
                provaStatus.Status = ProvaStatus.Finalizado;
                provaStatus.FinalizadoEm = ObterDatafim(questaoAlunoRespostaSincronizarDto.DataHoraRespostaTicks);
                await FinalizarProvaAluno(aluno.Ra, provaStatus);
            }

            return continuarProva;
        }

        private async Task FinalizarProvaAluno(long ra, ProvaAluno provaAluno)
        {
            await mediator.Send(new AtualizarProvaAlunoCommand(provaAluno));
            await PublicarAcompProvaAlunoInicioFimTratar(provaAluno.ProvaId, ra, (int)provaAluno.Status, provaAluno.CriadoEm, provaAluno.FinalizadoEm);
        }

        private static DateTime ObterDatafim(long? DataFim)
        {
            return (DataFim != null && DataFim > 0) ? new DateTime(DataFim.Value).AddHours(-3) : DateTime.Now.AddHours(-3);
        }

        private async Task PublicarAcompProvaAlunoInicioFimTratar(long provaId, long alunoRa, int status, DateTime? criadoEm, DateTime? finalizadoEm)
        {
            var provaAlunoAcompDto = new ProvaAlunoAcompDto(provaId, alunoRa, status, criadoEm, finalizadoEm);
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoInicioFimTratar, provaAlunoAcompDto));
        }

        private async Task AtualizarDadosCache(bool continuarProva, long provaId, Infra.Dtos.Aluno.DadosAlunoLogadoDto aluno, IEnumerable<QuestaoTaiDto> questoesAluno,
            IEnumerable<QuestaoAlternativaAlunoRespostaDto> alunoRespostas, Infra.Dtos.ApiR.ObterProximoItemApiRRespostaDto retorno)
        {

            if (continuarProva)
            {
                //-> atualiza a lista de itens do aluno
                var questoesAlunoAtualizado = questoesAluno.ToList();
                questoesAluno.Where(t => t.Id == retorno.ProximaQuestao).FirstOrDefault().Ordem = retorno.Ordem;

                //-> atualiza a ordem de das questoes no cache.
                var nomeChaveQuestaoAlunoTai = CacheChave.ObterChave(CacheChave.QuestaoAmostraTaiAluno, aluno.Ra, provaId);
                await mediator.Send(new SalvarCacheCommand(nomeChaveQuestaoAlunoTai, questoesAlunoAtualizado));
            }

            //-> atualiza a ultima proficiencia no cache.
            var nomeChaveUltimaProficienciaAluno = CacheChave.ObterChave(CacheChave.UltimaProficienciaProva, aluno.Ra, provaId);
            await mediator.Send(new SalvarCacheCommand(nomeChaveUltimaProficienciaAluno, retorno.Proficiencia));

            //-> Atualiza a lista de respostas do aluno no cache.
            var nomeChaveRespostaAluno = CacheChave.ObterChave(CacheChave.RespostaAmostraTaiAluno, aluno.Ra, provaId);
            await mediator.Send(new SalvarCacheCommand(nomeChaveRespostaAluno, alunoRespostas));
        }

        private async Task AtualizarDadosBanco(bool continuarProva, long provaId, QuestaoAlunoRespostaSincronizarDto questaoAlunoRespostaSincronizarDto, Dominio.Prova prova,
            Infra.Dtos.Aluno.DadosAlunoLogadoDto aluno, MeusDadosRetornoDto dados, Infra.Dtos.ApiR.ObterProximoItemApiRRespostaDto retorno)
        {
            //-> Serap estudantes
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirRespostaAluno, questaoAlunoRespostaSincronizarDto));

            //-> Serap acompanhamento
            var dtoAcompanhamento = new QuestaoAlunoRespostaAcompDto(0, questaoAlunoRespostaSincronizarDto.AlunoRa, questaoAlunoRespostaSincronizarDto.QuestaoId, questaoAlunoRespostaSincronizarDto.AlternativaId, questaoAlunoRespostaSincronizarDto.TempoRespostaAluno);
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoRespostaTratar, dtoAcompanhamento));

            if (continuarProva)
            {
                //-> Ordem da questão retornada pela api R
                await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarOrdemQuestaoAlunoProvaTai, new
                {
                    QuestaoId = retorno.ProximaQuestao,
                    Ordem = retorno.Ordem
                }));
            }

            //-> Proficiencia retornada pela api R
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarProficienciaAlunoProvaTai, new
            {
                ProvaId = provaId,
                AlunoId = dados.AlunoId,
                AlunoRa = aluno.Ra,
                Proficiencia = retorno.Proficiencia,
                Origem = 0,
                Tipo = continuarProva ? 1 : 2,
                DisciplinaId = prova.DisciplinaId
            }));
        }
    }
}
