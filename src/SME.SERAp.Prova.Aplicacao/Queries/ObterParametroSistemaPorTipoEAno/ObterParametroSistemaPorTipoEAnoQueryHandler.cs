using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterParametroSistemaPorTipoEAnoQueryHandler : IRequestHandler<ObterParametroSistemaPorTipoEAnoQuery, ParametroSistema>
    {
        private readonly IRepositorioParametroSistema repositorioParametroSistema;

        public ObterParametroSistemaPorTipoEAnoQueryHandler(IRepositorioParametroSistema repositorioParametroSistema)
        {
            this.repositorioParametroSistema = repositorioParametroSistema ?? throw new System.ArgumentNullException(nameof(repositorioParametroSistema));
        }
        public async Task<ParametroSistema> Handle(ObterParametroSistemaPorTipoEAnoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioParametroSistema.ObterPorTipoEAno((int)request.Tipo, request.Ano);
        }
    }
}
