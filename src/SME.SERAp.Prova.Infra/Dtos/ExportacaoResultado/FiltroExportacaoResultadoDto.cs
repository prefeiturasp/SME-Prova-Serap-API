using System;

namespace SME.SERAp.Prova.Infra
{
    public class FiltroExportacaoResultadoDto : DtoBase
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public long ProvaSerapId { get; set; }
        public string DescricaoProva { get; set; }
        public int QuantidadeRegistros { get; set; }
        public int NumeroPagina { get; set; }
    }
}
