using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class
        ObterPreferenciasUsuarioPorLoginQueryHandler : IRequestHandler<ObterPreferenciasUsuarioPorLoginQuery,
            PreferenciasUsuario>
    {
        private readonly IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario;

        public ObterPreferenciasUsuarioPorLoginQueryHandler(
            IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario)
        {
            this.repositorioPreferenciasUsuario = repositorioPreferenciasUsuario ??
                                                  throw new System.ArgumentNullException(
                                                      nameof(repositorioPreferenciasUsuario));
        }

        public async Task<PreferenciasUsuario> Handle(ObterPreferenciasUsuarioPorLoginQuery request,
            CancellationToken cancellationToken)
        {
            return await repositorioPreferenciasUsuario.ObterPorLogin(request.Login);
        }
    }
}