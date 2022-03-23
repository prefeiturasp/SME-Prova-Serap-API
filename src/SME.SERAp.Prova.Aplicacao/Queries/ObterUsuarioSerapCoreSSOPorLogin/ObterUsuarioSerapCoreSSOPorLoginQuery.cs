using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioSerapCoreSSOPorLoginQuery : IRequest<UsuarioSerapCoreSSO>
    {
        public ObterUsuarioSerapCoreSSOPorLoginQuery(string login)
        {
            Login = login;
        }

        public string Login { get; set; }
    }
}
