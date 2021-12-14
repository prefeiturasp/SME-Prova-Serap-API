using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlternativaPorIdQueryHandler : IRequestHandler<ObterAlternativaPorIdQuery, Alternativa>
    {
        private readonly IRepositorioAlternativa repositorioAlternativa;
        private readonly IRepositorioCache repositorioCache;

        public ObterAlternativaPorIdQueryHandler(IRepositorioAlternativa repositorioAlternativa, IRepositorioCache repositorioCache)
        {
            this.repositorioAlternativa = repositorioAlternativa ?? throw new System.ArgumentNullException(nameof(repositorioAlternativa));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<Alternativa> Handle(ObterAlternativaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterAsync($"a-{request.Id}", async () => await repositorioAlternativa.ObterPorIdAsync(request.Id));
        }
    }
}
