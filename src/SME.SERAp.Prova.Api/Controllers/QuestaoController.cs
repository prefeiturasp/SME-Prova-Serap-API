using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/questoes")]
    public class QuestaoController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestaoCompletaDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorId([FromQuery]long[] ids, [FromServices] IObterQuestoesCompletaPorIdsUseCase obterQuestoesCompletaPorIdsUseCase)
        {
            return Ok(await obterQuestoesCompletaPorIdsUseCase.Executar(ids));
        }
    }
}
