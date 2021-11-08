using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterContextoProvaPorIdQueryHandler : IRequestHandler<ObterContextoProvaPorIdQuery, ContextoProva>
    {
        private readonly IRepositorioContextoProva repositorioContextoProva;

        public ObterContextoProvaPorIdQueryHandler(IRepositorioContextoProva repositorioContextoProva)
        {
            this.repositorioContextoProva = repositorioContextoProva ?? throw new System.ArgumentNullException(nameof(repositorioContextoProva));
        }
        public async Task<ContextoProva> Handle(ObterContextoProvaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioContextoProva.ObterPorIdAsync(request.Id);
        }
    }
}
