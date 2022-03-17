using MediatR;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class GerarCodigoValidacaoAdmCommand : IRequest<string>
    {
        public GerarCodigoValidacaoAdmCommand(string login, Guid perfil)
        {
            Login = login;
            Perfil = perfil;
        }

        public string Login { get; set; }
        public Guid Perfil { get; set; }
    }
}
