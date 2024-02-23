using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioExportacaoResultado : IRepositorioBase<ExportacaoResultado>
    {
        Task<ExportacaoResultado> ObterPorProvaSerapIdAsync(long provaSerapId);
        Task<PaginacaoResultadoDto<ProvaExportacaoResultadoDto>> ObterPorFiltroDataPaginadaAsync(DateTime? dataInicio,
            DateTime? dataFim, long provaSerapId, int quantidadeRegistros, int numeroPagina);
    }
}