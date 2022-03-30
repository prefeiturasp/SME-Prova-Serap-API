using MediatR;
using SME.SERAp.Prova.Infra;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class GerarCodigoValidacaoAdmCommand : IRequest<AutenticacaoValidarAdmDto>
    {
        public GerarCodigoValidacaoAdmCommand(string login, string nome, Guid perfil)
        {
            Login = login;
            Nome = nome;
            Perfil = perfil;
        }

        public string Login { get; set; }
        public string Nome { get; set; }
        public Guid Perfil { get; set; }
    }
}
