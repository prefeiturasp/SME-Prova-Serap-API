using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterVersaoApiUseCase : IObterVersaoApiUseCase
    {
        private readonly IMediator mediator;

        public ObterVersaoApiUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<string> Executar()
        {
            return await mediator.Send(new ObterUltimaVersaoApiQuery());
        }
    }
}
