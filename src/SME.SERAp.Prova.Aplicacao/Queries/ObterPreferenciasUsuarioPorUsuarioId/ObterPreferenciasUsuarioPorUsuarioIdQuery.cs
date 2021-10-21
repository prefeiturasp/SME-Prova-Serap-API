using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterPreferenciasUsuarioPorUsuarioIdQuery : IRequest<PreferenciasUsuario>
    {
        public long UsuarioId { get; set; }
        
        public ObterPreferenciasUsuarioPorUsuarioIdQuery(long usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}