using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra
{
    public class PaginacaoResultadoDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalRegistros { get; set; }

        public bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
