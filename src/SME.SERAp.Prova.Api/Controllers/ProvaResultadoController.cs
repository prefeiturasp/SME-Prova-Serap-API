using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [Route("/api/v1/prova-resultados")]
    [ApiController]
    public class ProvaResultadoController : ControllerBase
    {
        public ProvaResultadoController()
        {

        }

        [HttpGet("{provaId}/{caderno}/resumo")]
        [ProducesResponseType(typeof(IEnumerable<ProvaResultadoResumoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvaResultadoResumo(long provaId, string caderno, [FromServices] IObterProvaResultadoResumoUseCase obterProvaResultadoResumoUseCase)
        {
            return Ok(await obterProvaResultadoResumoUseCase.Executar(provaId, caderno));
        }

        [HttpGet("{provaId}/{questaoLegadoId}/questao-completa")]
        [ProducesResponseType(typeof(QuestaoCompletaResultadoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterQuestaoCompletaResultado(long provaId, long questaoLegadoId, [FromServices] IObterQuestaoCompletaResultadoUseCase obterQuestaoCompletaResultadoUseCase)
        {
            return Ok(await obterQuestaoCompletaResultadoUseCase.Executar(provaId, questaoLegadoId));
        }
    }
}
