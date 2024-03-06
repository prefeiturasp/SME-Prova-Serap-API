using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaVersaoAppQueryHandler : IRequestHandler<ObterUltimaVersaoAppQuery, VersaoApp>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioVersaoApp repositorioVersaoApp;

        public ObterUltimaVersaoAppQueryHandler(IRepositorioVersaoApp repositorioVersaoApp, IRepositorioCache repositorioCache)
        {
            this.repositorioVersaoApp = repositorioVersaoApp ?? throw new System.ArgumentNullException(nameof(repositorioVersaoApp));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));  
        }
        public async Task<VersaoApp> Handle(ObterUltimaVersaoAppQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync("versaoApp", async () => await repositorioVersaoApp.ObterUltimaVersao());
        }
    }
}
