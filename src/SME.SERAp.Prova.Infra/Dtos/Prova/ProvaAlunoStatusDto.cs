using System;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaAlunoStatusDto
    {
        public ProvaAlunoStatusDto(int status, long? dataFim, int? tipoDispositivo)
        {
            Status = status;
            DataFim = dataFim;
            TipoDispositivo = tipoDispositivo;
        }

        public int Status { get; set; }
        public long? DataFim { get; set; }
        public int? TipoDispositivo { get; set; }

        public DateTime? DataFimMenos3Horas()
        {
            return DataFim.HasValue ? new DateTime(DataFim.Value).AddHours(-3) : DateTime.Now.AddHours(-3);
        }
    }
}
