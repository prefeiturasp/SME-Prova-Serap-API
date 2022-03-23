using MessagePack;
using System;

namespace SME.SERAp.Prova.Infra
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class AutenticacaoUsuarioAdmDto
    {
        public AutenticacaoUsuarioAdmDto() { }

        public AutenticacaoUsuarioAdmDto(string login, string nome, Guid perfil)
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
