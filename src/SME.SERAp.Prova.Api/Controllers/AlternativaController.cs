using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/alternativas")]
    public class AlternativaController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AlternativaDetalheRetornoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorId(long id, [FromServices] IObterAlternativaPorIdUseCase obterAlternativaPorIdUseCase)
        {
            return Ok(await obterAlternativaPorIdUseCase.Executar(id));
        }
    }
}