using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;
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

            //-> obter ultima proficiencia do aluno
            var proficiencia = await mediator.Send(new ObterUltimaProficienciaPorProvaQuery(provaId, questaoAlunoRespostaSincronizarDto.AlunoRa));

            //-> obter itens da amostra do aluno
            var questoesAluno = await mediator.Send(new ObterQuestaoTaiPorProvaAlunoQuery(provaId, questaoAlunoRespostaSincronizarDto.AlunoRa));

            //-> obter itens respondidos do aluno
            var alunoRespostas = await mediator.Send(new ObterAlternativaAlunoRespostaQuery(provaId, questaoAlunoRespostaSincronizarDto.AlunoRa));

            questoesAluno = questoesAluno.OrderBy(t => t.Id);
            alunoRespostas = alunoRespostas.OrderBy(t => t.QuestaoId);

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
                alunoRespostas.Select(t => t.AlternativaResposta).ToArray(),
                alunoRespostas.Select(t => t.AlternativaCorreta).ToArray(),
                alunoRespostas.Select(t => t.QuestaoId).ToArray()
                ));

            await AtualizarDadosBanco(provaId, questaoAlunoRespostaSincronizarDto, prova, aluno, dados, retorno);

            await AtualizarDadosCache(provaId, aluno, questoesAluno, alunoRespostas, questaoAlunoRespostaSincronizarDto, retorno);

            //-> Se o id retornado do tai ja foi aplicado finaliza a prova.
            return alunoRespostas.Any(t => t.QuestaoId != retorno.ProximaQuestao);
        }

        private async Task AtualizarDadosCache(long provaId, Infra.Dtos.Aluno.DadosAlunoLogadoDto aluno, IEnumerable<QuestaoTaiDto> questoesAluno, IEnumerable<QuestaoAlternativaAlunoRespostaDto> alunoRespostas, QuestaoAlunoRespostaSincronizarDto questaoAlunoRespostaSincronizarDto, Infra.Dtos.ApiR.ObterProximoItemApiRRespostaDto retorno)
        {
            //-> atualiza a lista de itens do aluno
            var questoesAlunoAtualizado = questoesAluno.ToList();
            questoesAluno.Where(t => t.Id == retorno.ProximaQuestao).FirstOrDefault().Ordem = retorno.Ordem;

            var nomeChaveQuestaoAlunoTai = CacheChave.ObterChave(CacheChave.QuestaoAmostraTaiAluno, aluno.Ra, provaId);
            await mediator.Send(new SalvarCacheCommand(nomeChaveQuestaoAlunoTai, questoesAlunoAtualizado));

            //-> atualiza a ultima proficiencia no cache.
            var nomeChaveUltimaProficienciaAluno = CacheChave.ObterChave(CacheChave.UltimaProficienciaProva, aluno.Ra, provaId);
            await mediator.Send(new SalvarCacheCommand(nomeChaveUltimaProficienciaAluno, retorno.Proficiencia));

            //-> atualiza a resposta do aluno no cache.
            var alunoRespostasAtualizado = alunoRespostas.ToList();
            alunoRespostas.Where(t => t.QuestaoId == retorno.ProximaQuestao).FirstOrDefault().AlternativaResposta = questaoAlunoRespostaSincronizarDto.AlternativaId.GetValueOrDefault();

            var nomeChaveRespostaAluno = CacheChave.ObterChave(CacheChave.RespostaAmostraTaiAluno, aluno.Ra, provaId);
            await mediator.Send(new SalvarCacheCommand(nomeChaveRespostaAluno, alunoRespostas));
        }

        private async Task AtualizarDadosBanco(long provaId, QuestaoAlunoRespostaSincronizarDto questaoAlunoRespostaSincronizarDto, Dominio.Prova prova, Infra.Dtos.Aluno.DadosAlunoLogadoDto aluno, MeusDadosRetornoDto dados, Infra.Dtos.ApiR.ObterProximoItemApiRRespostaDto retorno)
        {
            //-> Serap estudantes
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirRespostaAluno, questaoAlunoRespostaSincronizarDto));

            //-> Serap acompanhamento
            var dtoAcompanhamento = new QuestaoAlunoRespostaAcompDto(0, questaoAlunoRespostaSincronizarDto.AlunoRa, questaoAlunoRespostaSincronizarDto.QuestaoId, questaoAlunoRespostaSincronizarDto.AlternativaId, questaoAlunoRespostaSincronizarDto.TempoRespostaAluno);
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoRespostaTratar, dtoAcompanhamento));

            //-> Ordem da questão retornada pela api R
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarOrdemQuestaoAlunoProvaTai, new
            {
                QuestaoId = retorno.ProximaQuestao,
                Ordem = retorno.Ordem
            }));

            //-> Proficiencia retornada pela api R
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarProficienciaAlunoProvaTai, new
            {
                ProvaId = provaId,
                AlunoId = dados.AlunoId,
                AlunoRa = aluno.Ra,
                Proficiencia = retorno.Proficiencia,
                Origem = 0,
                Tipo = 1,
                DisciplinaId = prova.DisciplinaId
            }));
        }
    }
}
