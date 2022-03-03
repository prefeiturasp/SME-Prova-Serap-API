using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PotenciacaoRUseCase : IPotenciacaoRUseCase
    {

        private readonly IMediator mediator;

        public PotenciacaoRUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<string> Executar(int _base, int _expoente)
        {
            return await mediator.Send(new TesteFuncaoRQuery(_base, _expoente));
        }
    }
}
