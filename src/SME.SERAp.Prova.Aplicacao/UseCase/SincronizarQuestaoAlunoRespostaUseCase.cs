using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class SincronizarQuestaoAlunoRespostaUseCase : ISincronizarQuestaoAlunoRespostaUseCase
    {
        private readonly IMediator mediator;

        public SincronizarQuestaoAlunoRespostaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(QuestaoAlunoRespostaSincronizarDto dto)
        {
            //await mediator.Send(new IncluirQuestaoAlunoRespostaCacheCommand(dto));
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirRespostaAluno, dto));
        }
    }
}
