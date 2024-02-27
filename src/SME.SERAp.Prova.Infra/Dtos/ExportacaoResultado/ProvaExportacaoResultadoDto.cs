using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaExportacaoResultadoDto : DtoBase
    {
        public long ProvaId { get; set; }
        public long ProvaLegadoId { get; set; }
        public long ProcessoId { get; set; }
        public string Descricao { get; set; }
        public string NomeProva { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ExportacaoResultadoStatus Status { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? UltimaExportacao { get; set; }
    }
}
