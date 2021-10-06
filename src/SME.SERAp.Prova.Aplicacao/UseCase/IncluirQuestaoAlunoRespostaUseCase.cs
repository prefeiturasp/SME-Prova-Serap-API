using MediatR;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirQuestaoAlunoRespostaUseCase : IIncluirQuestaoAlunoRespostaUseCase
    {
        private readonly IMediator mediator;

        public IncluirQuestaoAlunoRespostaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar(long questaoId, long? alternativaId, string resposta, DateTime horaResposta,int tempoRespostaAluno)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var provaStatus = await mediator.Send(new ObterProvaAlunoPorQuestaoIdRaQuery(questaoId, alunoRa));

            if (provaStatus != null && provaStatus.Status == Dominio.ProvaStatus.Finalizado)
                throw new NegocioException("Esta prova já foi finalizada", 411);

            var questaoRespondida = await mediator.Send(new ObterQuestaoAlunoRespostaPorIdRaQuery(questaoId, alunoRa));
                      
            if (questaoRespondida == null)
            {
                return await mediator.Send(new IncluirQuestaoAlunoRespostaCommand(questaoId, alunoRa, alternativaId, resposta, horaResposta, tempoRespostaAluno));
            } else if (questaoRespondida.CriadoEm > horaResposta) 
            {
                return false;
            }else
            {
                questaoRespondida.Resposta = resposta;
                questaoRespondida.TempoRespostaAluno += tempoRespostaAluno;

                return await mediator.Send(new AtualizarQuestaoAlunoRespostaCommand(questaoRespondida));
            }

        }
    }
}
