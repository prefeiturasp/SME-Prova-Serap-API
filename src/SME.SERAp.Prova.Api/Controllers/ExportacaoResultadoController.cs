using Microsoft.AspNetCore.Authorization;
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
        public ExportacaoResultadoController()
        {
        }

        [HttpGet("{provaSerapId}/status")]
        [ProducesResponseType(typeof(IEnumerable<ObterProvasRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterStatus(long provaSerapId, [FromServices] IObterExportacaoResultadoStatusUseCase obterExportacaoResultadoStatus)
        {
            return Ok(await obterExportacaoResultadoStatus.Executar(provaSerapId));
        }
    }
}
