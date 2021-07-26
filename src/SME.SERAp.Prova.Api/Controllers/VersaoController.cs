using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/versoes")]
    public class VersaoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObterVersaoApi([FromServices] IObterVersaoApiUseCase obterVersaoApiUseCase)
        {
            return Ok(await obterVersaoApiUseCase.Executar());
        }
        [HttpGet("front")]
        public async Task<IActionResult> ObterVersaoFront([FromServices] IObterVersaoFrontUseCase obterVersaoFrontUseCase)
        {
            return Ok(await obterVersaoFrontUseCase.Executar());
        }
    }
}
