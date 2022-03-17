using MediatR;
using SME.SERAp.Prova.Infra;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class GerarCodigoValidacaoAdmCommand : IRequest<AutenticacaoValidarAdmDto>
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
