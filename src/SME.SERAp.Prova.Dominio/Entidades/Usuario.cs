using System;

namespace SME.SERAp.Prova.Dominio
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public long Login { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime UltimoLogin { get; set; }

        public Usuario()
        {
        }

        public Usuario(string nome, long login)
        {
            Nome = nome;
            Login = login;
            CriadoEm  = DateTime.Now;
            UltimoLogin = DateTime.Now;
        }

        public void AtualizaUltimoLogin()
        {
            UltimoLogin = DateTime.Now;
        }
    }
}