using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class HangfireMediator
    {
        private readonly IMediator _mediator;

        public HangfireMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SendCommand<T>(IRequest<T> request)
        {
            _mediator.Send(request);
        }
    }
}
