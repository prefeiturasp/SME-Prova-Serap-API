using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra
{
    public class ImportArquivoResultadoPspDto : DtoBase
    {
        public ImportArquivoResultadoPspDto()
        {

        }

        public long ProcessoId { get; set; }
        public string TabelaResultados { get; set; }

    }
}
