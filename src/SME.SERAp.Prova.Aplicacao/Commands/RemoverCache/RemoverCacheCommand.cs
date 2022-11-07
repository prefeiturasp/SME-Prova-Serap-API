using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class RemoverCacheCommand : IRequest<bool>
    {
        public RemoverCacheCommand(string nomeChave)
        {
            NomeChave = nomeChave;
        }

        public string NomeChave { get; set; }
    }
}
