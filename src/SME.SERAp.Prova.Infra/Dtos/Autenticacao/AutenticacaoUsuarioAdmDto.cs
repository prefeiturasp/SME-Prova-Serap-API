using MessagePack;
using System;

namespace SME.SERAp.Prova.Infra
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class AutenticacaoUsuarioAdmDto
    {
        public AutenticacaoUsuarioAdmDto() { }

        public AutenticacaoUsuarioAdmDto(string login, Guid perfil)
        {
            Login = login;
            Perfil = perfil;
        }

        public string Login { get; set; }
        public Guid Perfil { get; set; }
    }
}
