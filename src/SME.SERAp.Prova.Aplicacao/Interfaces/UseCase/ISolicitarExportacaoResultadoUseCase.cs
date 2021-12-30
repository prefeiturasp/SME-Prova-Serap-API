using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface ISolicitarExportacaoResultadoUseCase
    {
        public Task<bool> Executar(long provaSerapId);
    }
}
