using System;

namespace SME.SERAp.Prova.Dominio
{
    public class ExportacaoResultado : EntidadeBase
    {
        public ExportacaoResultado()
        {

        }

        public ExportacaoResultado(string nomeArquivo, long provaSerapId)
        {
            NomeArquivo = nomeArquivo;
            Status = ExportacaoResultadoStatus.Processando;
            CriadoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
            ProvaSerapId = provaSerapId;
        }

        public string NomeArquivo { get; set; }
        public ExportacaoResultadoStatus Status { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public long ProvaSerapId { get; set; }

        public void AtualizarStatus(ExportacaoResultadoStatus status)
        {
            Status = status;
            AtualizadoEm = DateTime.Now;
        }
    }
}