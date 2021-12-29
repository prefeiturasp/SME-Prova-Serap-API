using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra
{
   public class ProvaExportacaoResultadoDto
    {
        public long ProvaId { get; set; }
        public long ProvaLegadoId { get; set; }
        public string Descricao { get; set; }
        public string NomeProva { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ExportacaoResultadoStatus Status { get; set; }
       
    }
}
