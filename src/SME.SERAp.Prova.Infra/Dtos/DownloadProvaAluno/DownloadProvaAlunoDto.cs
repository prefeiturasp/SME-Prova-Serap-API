using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class DownloadProvaAlunoDto : DtoBase
    {
        public Guid Codigo { get; set; }
        public long AlunoRa { get; set; }
        public long ProvaId { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public string DispositivoId { get; set; }
        public string ModeloDispositivo { get; set; }
        public string Versao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
