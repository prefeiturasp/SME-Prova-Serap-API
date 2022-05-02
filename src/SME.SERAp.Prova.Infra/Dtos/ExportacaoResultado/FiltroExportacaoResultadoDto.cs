using System;

namespace SME.SERAp.Prova.Infra
{
    public class FiltroExportacaoResultadoDto : DtoBase
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public long ProvaSerapId { get; set; }
          
    }
}
