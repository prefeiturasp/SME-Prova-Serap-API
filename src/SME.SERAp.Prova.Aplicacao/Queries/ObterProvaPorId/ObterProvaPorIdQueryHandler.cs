using MediatR;
using SME.SERAp.Prova.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaPorIdQueryHandler : IRequestHandler<ObterProvaPorIdQuery, Dominio.Prova>
    {
        private readonly IRepositorioProva repositorioProva;
        private readonly IRepositorioCache repositorioCache;

        public ObterProvaPorIdQueryHandler(IRepositorioProva repositorioProva, IRepositorioCache repositorioCache)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<Dominio.Prova> Handle(ObterProvaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterAsync($"p-{request.ProvaId}", async () => await repositorioProva.ObterPorIdAsync(request.ProvaId));
        }
    }
}
