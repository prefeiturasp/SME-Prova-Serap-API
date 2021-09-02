using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/arquivos")]
    public class ArquivoController : Controller
    {

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArquivoRetornoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorId(long id, [FromServices] IObterArquivoPorIdUseCase obterArquivoPorIdUseCase)
        {

            return Ok(await obterArquivoPorIdUseCase.Executar(id));
        }
        [HttpGet("{id}/legado")]
        [ProducesResponseType(typeof(ArquivoRetornoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorIdLegado(long id, [FromServices] IObterArquivoPorIdLegadoUseCase obterArquivoPorIdLegadoUseCase)
        {

            return Ok(await obterArquivoPorIdLegadoUseCase.Executar(id));
        }
    }
}
