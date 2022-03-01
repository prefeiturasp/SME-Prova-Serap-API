using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra.Dtos
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
