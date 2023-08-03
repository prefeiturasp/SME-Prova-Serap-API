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

            if (prova == null)
                throw new NegocioException($"Prova {provaId} não localizada.");

            //-> dados do aluno 
            var aluno = await mediator.Send(new ObterDadosAlunoLogadoQuery());
            var alunoRa = aluno.Ra;

            if (alunoRa <= 0)
                alunoRa = questaoAlunoRespostaSincronizarDto.AlunoRa;
            
            var dados = await mediator.Send(new ObterDetalhesAlunoCacheQuery(alunoRa));

            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, alunoRa));
            
            if (provaStatus is not { Status: ProvaStatus.Iniciado })
                throw new NegocioException("Esta prova precisa ser iniciada.", 411);

            //-> obter ultima proficiencia do aluno
            var proficiencia = await mediator.Send(new ObterUltimaProficienciaPorProvaQuery(provaId, alunoRa));

            //-> obter itens da amostra do aluno
            var questoesAluno = (await mediator.Send(new ObterQuestaoTaiPorProvaAlunoQuery(provaId, alunoRa)))
                .OrderBy(t => t.Id)
                .ToList();

            //-> obter alternativas e respostas
            var alunoRespostas = (await mediator.Send(new ObterAlternativaAlunoRespostaQuery(provaId, alunoRa))).ToList();

            //-> atualiza a resposta do aluno no cache.
            var alunoRespostasAtualizado = alunoRespostas
                .Where(t => t.QuestaoId == questaoAlunoRespostaSincronizarDto.QuestaoId)
                .ToList();

            var primeiraRespostaAluno = alunoRespostasAtualizado.FirstOrDefault();

            if (primeiraRespostaAluno != null)
                primeiraRespostaAluno.AlternativaResposta = questaoAlunoRespostaSincronizarDto.AlternativaId;
            
            //-> Obter alternativas com respotas
            var alternativasComRespostas = alunoRespostas.Where(c => c.AlternativaResposta.HasValue).ToList();
            
            //-> Obter proximo item
            var respotas = alternativasComRespostas.Select(c => c.AlternativaResposta.GetValueOrDefault()).ToArray();
            var gabarito = alternativasComRespostas.Select(c => c.AlternativaCorreta).ToArray();
            var administrado = questoesAluno.Where(t => t.Ordem != 999).Select(t => t.Id).ToArray();

            var retorno = await mediator.Send(new ObterProximoItemApiRQuery(
                dados.AlunoId.ToString(),
                dados.Ano,
                proficiencia,
                questoesAluno.Select(t => t.Id).ToArray(),
                questoesAluno.Select(t => t.Discriminacao).ToArray(),
                questoesAluno.Select(t => t.ProporcaoAcertos).ToArray(),
                questoesAluno.Select(t => t.AcertoCasual).ToArray(),
                (int)prova.ProvaFormatoTaiItem.GetValueOrDefault(),
                respotas,
                gabarito,
                administrado,
                prova.Disciplina
                )
            );

            //-> Se o id da questão retornado do tai não foi respondido continua a prova.
            var continuarProva = retorno.ProximaQuestao != -1;

            await AtualizarDadosBanco(continuarProva, provaId, questaoAlunoRespostaSincronizarDto, prova, aluno, dados, retorno);
            await AtualizarDadosCache(continuarProva, provaId, aluno, questoesAluno, alunoRespostas, retorno);

            if (continuarProva) 
                return true;
            
            provaStatus.Status = ProvaStatus.Finalizado;
            provaStatus.FinalizadoEm = ObterDatafim(questaoAlunoRespostaSincronizarDto.DataHoraRespostaTicks);

            await FinalizarProvaAluno(aluno.Ra, provaStatus);

            return false;
        }

        private async Task FinalizarProvaAluno(long ra, ProvaAluno provaAluno)
        {
            await mediator.Send(new AtualizarProvaAlunoCommand(provaAluno));
            await PublicarAcompProvaAlunoInicioFimTratar(provaAluno.ProvaId, ra, (int)provaAluno.Status, provaAluno.CriadoEm, provaAluno.FinalizadoEm);
        }

        private static DateTime ObterDatafim(long? dataFim)
        {
            return dataFim is > 0 ? new DateTime(dataFim.Value).AddHours(-3) : DateTime.Now.AddHours(-3);
        }

        private async Task PublicarAcompProvaAlunoInicioFimTratar(long provaId, long alunoRa, int status, DateTime? criadoEm, DateTime? finalizadoEm)
        {
            var provaAlunoAcompDto = new ProvaAlunoAcompDto(provaId, alunoRa, status, criadoEm, finalizadoEm);
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoInicioFimTratar, provaAlunoAcompDto));
        }

        private async Task AtualizarDadosCache(bool continuarProva, long provaId, Infra.Dtos.Aluno.DadosAlunoLogadoDto aluno, IList<QuestaoTaiDto> questoesAluno,
            IEnumerable<QuestaoAlternativaAlunoRespostaDto> alunoRespostas, Infra.Dtos.ApiR.ObterProximoItemApiRRespostaDto retorno)
        {
            if (continuarProva)
            {
                //-> atualiza a lista de itens do aluno
                var questaoTai = questoesAluno.FirstOrDefault(t => t.Id == retorno.ProximaQuestao);

                if (questaoTai != null)
                    questaoTai.Ordem = retorno.Ordem;

                //-> atualiza a ordem de das questoes no cache.
                var nomeChaveQuestaoAlunoTai = CacheChave.ObterChave(CacheChave.QuestaoAmostraTaiAluno, aluno.Ra, provaId);
                await mediator.Send(new SalvarCacheCommand(nomeChaveQuestaoAlunoTai, questoesAluno));
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
            var dtoAcompanhamento = new QuestaoAlunoRespostaAcompDto(0, questaoAlunoRespostaSincronizarDto.AlunoRa,
                questaoAlunoRespostaSincronizarDto.QuestaoId, questaoAlunoRespostaSincronizarDto.AlternativaId,
                questaoAlunoRespostaSincronizarDto.TempoRespostaAluno);
            
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoRespostaTratar, dtoAcompanhamento));

            if (continuarProva)
            {
                //-> Ordem da questão retornada pela api R
                await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarOrdemQuestaoAlunoProvaTai, new
                {
                    QuestaoId = retorno.ProximaQuestao,
                    retorno.Ordem
                }));
            }

            //-> Proficiencia retornada pela api R
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarProficienciaAlunoProvaTai, new
            {
                ProvaId = provaId,
                dados.AlunoId,
                AlunoRa = aluno.Ra,
                retorno.Proficiencia,
                Origem = 0,
                Tipo = continuarProva ? 1 : 2,
                prova.DisciplinaId
            }));
        }
    }
}
