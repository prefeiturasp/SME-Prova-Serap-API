using System;

namespace SME.SERAp.Prova.Dominio
{
    public class ProvaAluno : EntidadeBase
    {

        public ProvaAluno()
        {
            CriadoEm = DateTime.Now;
        }
        public ProvaAluno(long provaId, ProvaStatus status, long alunoRa, DateTime criadoEm, DateTime? finalizadoEm, TipoDispositivo tipoDispositivo, string dispositivoId)
        {
            ProvaId = provaId;
            Status = status;
            CriadoEm = criadoEm;
            AlunoRA = alunoRa;
            FinalizadoEm = finalizadoEm;
            TipoDispositivo = tipoDispositivo;
            DispositivoId = dispositivoId;
        }

        public long ProvaId { get; set; }
        public long AlunoRA { get; set; }
        public ProvaStatus Status { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public FrequenciaAluno Frequencia { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public string DispositivoId { get; set; }

    }
}
