using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioSerapCoreSSOPorLoginQueryHandler : IRequestHandler<ObterUsuarioSerapCoreSSOPorLoginQuery, UsuarioSerapCoreSSO>
    {
        private readonly IRepositorioUsuarioSerapCoreSSO repositorioUsuarioSerapCoreSSO;

        public ObterUsuarioSerapCoreSSOPorLoginQueryHandler(IRepositorioUsuarioSerapCoreSSO repositorioUsuarioSerapCoreSSO)
        {
            this.repositorioUsuarioSerapCoreSSO = repositorioUsuarioSerapCoreSSO ?? throw new System.ArgumentNullException(nameof(repositorioUsuarioSerapCoreSSO));
        }

        public async Task<UsuarioSerapCoreSSO> Handle(ObterUsuarioSerapCoreSSOPorLoginQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuarioSerapCoreSSO.ObterPorLogin(request.Login);
        }
    }
}
