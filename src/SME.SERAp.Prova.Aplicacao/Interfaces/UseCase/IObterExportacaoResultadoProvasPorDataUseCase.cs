﻿using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterExportacaoResultadoProvasPorDataUseCase
    {
        public Task<PaginacaoResultadoDto<ExportacaoRetornoSerapDto>> Executar(FiltroExportacaoResultadoDto filtro);
    }
}
