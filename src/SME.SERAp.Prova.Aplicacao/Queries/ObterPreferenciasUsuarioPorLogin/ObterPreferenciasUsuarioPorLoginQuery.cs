using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterPreferenciasUsuarioPorLoginQuery : IRequest<PreferenciasUsuario>
    {
        public long Login { get; set; }
        
        public ObterPreferenciasUsuarioPorLoginQuery(long login)
        {
            Login = login;
        }
    }
}