using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]    
    [Route("/api/v1/exportacoes-resultados")]
    public class ExportacaoResultadoController : ControllerBase
    {
        public ExportacaoResultadoController(){}

        [HttpGet("{provaSerapId}/status")]
        [ProducesResponseType(typeof(IEnumerable<ObterProvasRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterStatus(long provaSerapId, [FromServices] IObterExportacaoResultadoStatusUseCase obterExportacaoResultadoStatus)
        {
            return Ok(await obterExportacaoResultadoStatus.Executar(provaSerapId));
        }

        [HttpGet("{provaSerapId}/exportar")]
        [ProducesResponseType(typeof(IEnumerable<bool>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> IniciarExportacao(long provaSerapId, [FromServices] ISolicitarExportacaoResultadoUseCase solicitarExportacaoResultadoUseCase)
        {
            return Ok(await solicitarExportacaoResultadoUseCase.Executar(provaSerapId));
        }

        [HttpPost("exportacoes-status")]
        [ProducesResponseType(typeof(IEnumerable<ExportacaoRetornoSerapDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterExportacaoDeProvasPorDataInicioFimEProvaId(FiltroExportacaoResultadoDto filtroExportacao, [FromServices] IObterExportacaoResultadoProvasPorDataUseCase obterExportacaoResultadoProvasPorData)
        {
            return Ok(await obterExportacaoResultadoProvasPorData.Executar(filtroExportacao));
        }

        [HttpGet("{processoId}/download")]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> DownloadArquivoResultadoProva(long processoId, [FromServices] IDownloadArquivoResultadoProvaUseCase downloadArquivoResultadoProvaUseCase)
        {
            var (arquivo, nomeArquivo) = await downloadArquivoResultadoProvaUseCase.Executar(processoId);
            return File(arquivo, "application/csv", nomeArquivo);
        }
    }
}
