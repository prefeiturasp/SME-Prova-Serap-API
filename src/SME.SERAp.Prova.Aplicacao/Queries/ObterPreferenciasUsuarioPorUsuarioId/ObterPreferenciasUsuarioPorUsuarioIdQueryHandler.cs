using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class
        ObterPreferenciasUsuarioPorUsuarioIdQueryHandler : IRequestHandler<ObterPreferenciasUsuarioPorUsuarioIdQuery,
            PreferenciasUsuario>
    {
        private readonly IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario;

        public ObterPreferenciasUsuarioPorUsuarioIdQueryHandler(
            IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario)
        {
            this.repositorioPreferenciasUsuario = repositorioPreferenciasUsuario ??
                                                  throw new System.ArgumentNullException(
                                                      nameof(repositorioPreferenciasUsuario));
        }

        public async Task<PreferenciasUsuario> Handle(ObterPreferenciasUsuarioPorUsuarioIdQuery request,
            CancellationToken cancellationToken)
        {
            return await repositorioPreferenciasUsuario.ObterPorUsuarioId(request.UsuarioId);
        }
    }
}