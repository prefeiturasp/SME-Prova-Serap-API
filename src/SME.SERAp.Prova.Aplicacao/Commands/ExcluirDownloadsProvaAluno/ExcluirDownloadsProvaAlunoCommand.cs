using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
   public class ExcluirDownloadsProvaAlunoCommand : IRequest<bool>
    {
        public ExcluirDownloadsProvaAlunoCommand(int[] ids)
        {
            Ids = ids;
        }

        public int[] Ids { get; set; }
    }
}
