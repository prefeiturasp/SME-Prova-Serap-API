﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/questoes")]
    public class QuestaoController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestaoDetalheRetornoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorId(long id, [FromServices] IObterQuestaoPorIdUseCase obterQuestaoPorIdUseCase)
        {
            return Ok(await obterQuestaoPorIdUseCase.Executar(id));
        }
    }
}