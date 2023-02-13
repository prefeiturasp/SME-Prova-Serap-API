using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.SERAp.Prova.Infra
{
    public class ArquivoResultadoPspDto : DtoBase
    {
        public ArquivoResultadoPspDto() { }

        public long Id { get; set; }
        public long CodigoTipoResultado { get; set; }
        public string NomeArquivo { get; set;}
        public string NomeOriginalArquivo { get; set;}
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int State { get; set; }
    }
}
