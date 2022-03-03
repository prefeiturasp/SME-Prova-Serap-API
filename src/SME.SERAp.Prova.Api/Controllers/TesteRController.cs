using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/teste-r")]
    public class TesteRController : Controller
    {
        [HttpGet("potenciacao/{_base}/{_expoente}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterPorId(int _base, int _expoente, [FromServices] IPotenciacaoRUseCase potenciacaoRUseCase)
        {
            return Ok(await potenciacaoRUseCase.Executar(_base, _expoente));
        }
    }
}
