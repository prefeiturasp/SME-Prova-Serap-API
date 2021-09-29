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
        public async Task<bool> Executar(long questaoId, long? alternativaId, string resposta, DateTime horaResposta)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var provaStatus = await mediator.Send(new ObterProvaAlunoPorQuestaoIdRaQuery(questaoId, alunoRa));

            if (provaStatus.Status == Dominio.ProvaStatus.Finalizado)
                throw new NegocioException("Esta prova já foi finalizada", 411);

            var questaoRespondida = await mediator.Send(new ObterQuestaoAlunoRespostaPorIdRaQuery(questaoId, alunoRa));
                      
            if (questaoRespondida == null)
            {
                return await mediator.Send(new IncluirQuestaoAlunoRespostaCommand(questaoId, alunoRa, alternativaId, resposta, horaResposta));
            } else if (questaoRespondida.CriadoEm > horaResposta) 
            {
                return false;
            }else
            {
                await mediator.Send(new ExcluirQuestaoAlunoRespostaPorIdCommand(questaoRespondida));
                return await mediator.Send(new IncluirQuestaoAlunoRespostaCommand(questaoId, alunoRa, alternativaId, resposta, horaResposta));
            }

        }
    }
}
