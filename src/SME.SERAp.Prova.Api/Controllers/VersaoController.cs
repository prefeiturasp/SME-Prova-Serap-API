using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/versoes")]
    public class VersaoController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterVersaoApi([FromServices] IObterVersaoApiUseCase obterVersaoApiUseCase)
        {
            return Ok(await obterVersaoApiUseCase.Executar());
        }
        [HttpGet("front")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterVersaoFront([FromServices] IObterVersaoFrontUseCase obterVersaoFrontUseCase)
        {
            return Ok(await obterVersaoFrontUseCase.Executar());
        }

        [HttpGet("atualizacao")]
        [ProducesResponseType(typeof(VersaoAppDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterUltimaVersaoApp([FromServices] IObterVersaoAppUseCase obterUltimaVersaoUseCase)
        {
            return Ok(await obterUltimaVersaoUseCase.Executar());
        }

        [ValidaDto]
        [ChaveAutenticacaoApi]
        [HttpPost("dispositivo")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterUltimaVersaoApp([FromBody] VersaoAppDispositivoDto versaoAppDispositivoDto, [FromServices] IIncluirVersaoAppDispositivoUseCase obterUltimaVersaoUseCase)
        {
            return Ok(await obterUltimaVersaoUseCase.Executar(versaoAppDispositivoDto));
        }
    }
}
