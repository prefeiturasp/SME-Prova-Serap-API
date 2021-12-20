using System;

namespace SME.SERAp.Prova.Dominio
{
    public class ExportacaoResultado : EntidadeBase
    {
        public ExportacaoResultado()
        {

        }
        public string NomeArquivo { get; set; }
        public ExportacaoResultadoStatus Status { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public long ProvaSerapId { get; set; }
    }
}