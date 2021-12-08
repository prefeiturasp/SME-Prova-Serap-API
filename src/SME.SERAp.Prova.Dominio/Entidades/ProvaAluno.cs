using System;

namespace SME.SERAp.Prova.Dominio
{
    public class ProvaAluno : EntidadeBase
    {
        public ProvaAluno()
        {
            CriadoEm = DateTime.Now;
        }

        public ProvaAluno(long provaId, ProvaStatus status, long alunoRa, DateTime criadoEm, DateTime? finalizadoEm)
        {
            ProvaId = provaId;
            Status = status;
            CriadoEm = criadoEm;
            AlunoRA = alunoRa;
            FinalizadoEm = finalizadoEm;
        }

        public long ProvaId { get; set; }
        public long AlunoRA { get; set; }
        public ProvaStatus Status { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }

        public DateTime ObterCriadoMenos3Horas ()
        {
            return CriadoEm.AddHours(-3);
        }
    }
}
