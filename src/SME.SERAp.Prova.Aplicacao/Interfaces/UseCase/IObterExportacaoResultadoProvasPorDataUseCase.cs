using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterExportacaoResultadoProvasPorDataUseCase
    {
        public Task<IEnumerable<ExportacaoRetornoSerapDto>> Executar(FiltroExportacaoResultadoDto filtro);
    }
}
