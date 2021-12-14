using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterParametroSistemaPorTipoEAnoQueryHandler : IRequestHandler<ObterParametroSistemaPorTipoEAnoQuery, ParametroSistema>
    {
        private readonly IRepositorioParametroSistema repositorioParametroSistema;
        private readonly IRepositorioCache repositorioCache;

        public ObterParametroSistemaPorTipoEAnoQueryHandler(IRepositorioParametroSistema repositorioParametroSistema, IRepositorioCache repositorioCache)
        {
            this.repositorioParametroSistema = repositorioParametroSistema ?? throw new System.ArgumentNullException(nameof(repositorioParametroSistema));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<ParametroSistema> Handle(ObterParametroSistemaPorTipoEAnoQuery request, CancellationToken cancellationToken)
        {
            var parametrosDoSistema = await repositorioCache.ObterRedisAsync("parametros", async () => await repositorioParametroSistema.ObterTudoAsync(), 1440);

            if (parametrosDoSistema != null && parametrosDoSistema.Any())
                return parametrosDoSistema.FirstOrDefault(a => a.Ano == request.Ano && a.Tipo == request.Tipo);            
            else 
                return default;
        }
    }
}
