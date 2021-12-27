using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra
{
    public class ExportacaoResultadoCacheDto
    {
        public long Id { get; set; }
        public long ProvaSerapId { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int Status { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
