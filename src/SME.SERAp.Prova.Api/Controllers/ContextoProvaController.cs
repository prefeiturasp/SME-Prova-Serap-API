using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/contextos-provas")]
    public class ContextoProvaController : ControllerBase
    {
        public ContextoProvaController()
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContextoProvaDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorId(long id, [FromServices] IObterContextoProvaPorIdUseCase obterContextoProvaPorIdUseCase)
        {
            return Ok(await obterContextoProvaPorIdUseCase.Executar(id));
        }

        [HttpGet("provas/{provaId}")]
        [ProducesResponseType(typeof(IEnumerable<ContextoProvaDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorProvaId(long provaId, [FromServices] IObterContextosProvasPorProvaIdUseCase obterContextoProvaPorProvaIdUseCase)
        {
            return Ok(await obterContextoProvaPorProvaIdUseCase.Executar(provaId));
        }
    }
}
