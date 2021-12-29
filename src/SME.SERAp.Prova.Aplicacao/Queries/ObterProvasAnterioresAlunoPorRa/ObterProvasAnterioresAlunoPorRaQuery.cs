using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAnterioresAlunoPorRaQuery : IRequest<IEnumerable<ProvaAlunoAnoDto>>
    {
        public ObterProvasAnterioresAlunoPorRaQuery(long ra)
        {
            Ra = ra;
        }

        public long Ra { get; set; }
    }
}
