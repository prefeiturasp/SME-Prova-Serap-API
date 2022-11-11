using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterProvaResultadoResumoUseCase : IObterProvaResultadoResumoUseCase
    {

        private readonly IMediator mediator;

        public ObterProvaResultadoResumoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<ProvaResultadoResumoDto> Executar(long provaId, int caderno)
        {
            return default;
        }
    }
}
