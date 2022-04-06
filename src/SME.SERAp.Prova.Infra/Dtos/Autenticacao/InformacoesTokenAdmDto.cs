using System;

namespace SME.SERAp.Prova.Infra
{
    public class InformacoesTokenAdmDto
    {
        public InformacoesTokenAdmDto(string login, string nome, Guid perfil)
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
