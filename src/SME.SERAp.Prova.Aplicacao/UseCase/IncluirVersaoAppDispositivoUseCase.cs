using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class IncluirVersaoAppDispositivoUseCase : IIncluirVersaoAppDispositivoUseCase
    {
        private readonly IMediator mediator;

        public IncluirVersaoAppDispositivoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(VersaoAppDispositivoDto versaoAppDispositivoDto)
        {
            return await mediator.Send(new IncluirVersaoAppDispositivoCommand(versaoAppDispositivoDto));
        }
    }
}
