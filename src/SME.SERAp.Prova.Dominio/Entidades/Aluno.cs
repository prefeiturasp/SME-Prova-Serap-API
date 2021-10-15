using System;

namespace SME.SERAp.Prova.Dominio
{
    public class Aluno: EntidadeBase
    {
        public string Nome { get; set; }
        public long RA { get; set; }
        public DateTime UltimoLogin { get; set; }

        public Aluno()
        {

        }

        public Aluno(string nome, long ra)
        {
            Nome = nome;
            RA = ra;
            UltimoLogin = DateTime.Now;
        }

        public void AtualizaUltimoLogin()
        {
            UltimoLogin = DateTime.Now;
        }
    }
}
