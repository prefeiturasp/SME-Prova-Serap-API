using MediatR;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class VerificaConexaoComServicoRUseCase : AbstractUseCase , IVerificaConexaoComServicoRUseCase
    {
        public VerificaConexaoComServicoRUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar()
        {
            return await mediator.Send(new TesteConexaoApiRQuery());
        }
    }
}
