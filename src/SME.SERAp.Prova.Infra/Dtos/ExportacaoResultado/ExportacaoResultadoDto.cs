using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class ExportacaoResultadoDto : DtoBase
    {
        public ExportacaoResultadoDto(long provaSerapId, string nomeArquivo, DateTime criadoEm, DateTime atualizadoEm, ExportacaoResultadoStatus status)
        {
            ProvaSerapId = provaSerapId;
            CriadoEm = criadoEm;
            NomeArquivo = nomeArquivo;
            AtualizadoEm = atualizadoEm;
            Status = status;
        }

        public long ProvaSerapId { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public ExportacaoResultadoStatus Status { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
