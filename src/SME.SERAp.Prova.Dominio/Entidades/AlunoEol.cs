﻿namespace SME.SERAp.Prova.Dominio
{
    public class AlunoEol
    {
        public string Nome { get; set; }
        public string NomeSocial { get; set; }

        public string NomeFinal()
        {
            return Nome;
        }
    }
}
