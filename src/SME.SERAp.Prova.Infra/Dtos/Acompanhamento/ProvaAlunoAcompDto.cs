using System;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaAlunoAcompDto
    {
        public ProvaAlunoAcompDto()
        {

        }
        public ProvaAlunoAcompDto(long provaId, long alunoRa, int status, DateTime? criadoEm, DateTime? finalizadoEm)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
            Status = status;
            CriadoEm = criadoEm;
            FinalizadoEm = finalizadoEm;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
        public int Status { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
    }
}
