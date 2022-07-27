using System;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaAlunoStatusDto : DtoBase
    {
        public ProvaAlunoStatusDto(int status, long? dataInicio, long? dataFim, int? tipoDispositivo)
        {
            Status = status;
            DataFim = dataFim;
            TipoDispositivo = tipoDispositivo;
        }

        public int Status { get; set; }
        public long? DataInicio { get; set; }
        public long? DataFim { get; set; }
        public int? TipoDispositivo { get; set; }

        public DateTime? DataMenos3Horas(long? data)
        {
            return data.HasValue ? new DateTime(data.Value).AddHours(-3) : DateTime.Now.AddHours(-3);
        }

    }
}
