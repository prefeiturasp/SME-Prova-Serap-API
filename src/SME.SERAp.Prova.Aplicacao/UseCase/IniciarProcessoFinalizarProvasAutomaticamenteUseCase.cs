using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IniciarProcessoFinalizarProvasAutomaticamenteUseCase : IIniciarProcessoFinalizarProvasAutomaticamenteUseCase
    {
        private readonly IMediator mediator;
        public IniciarProcessoFinalizarProvasAutomaticamenteUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IniciarProcessoFinalizarProvasAutomaticamente));
        }
    }
}
