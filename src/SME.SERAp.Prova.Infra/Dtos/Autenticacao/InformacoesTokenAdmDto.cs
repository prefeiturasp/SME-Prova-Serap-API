using System;

namespace SME.SERAp.Prova.Infra
{
    public class InformacoesTokenAdmDto
    {
        public InformacoesTokenAdmDto(string login, Guid perfil)
        {
            Login = login;
            Perfil = perfil;
        }

        public string Login { get; set; }
        public Guid Perfil { get; set; }
    }
}
