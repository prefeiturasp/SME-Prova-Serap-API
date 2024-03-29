﻿using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestaoDetalheRetornoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterPorId(long id, [FromServices] IObterQuestaoPorIdUseCase obterQuestaoPorIdUseCase)
        {
            return Ok(await obterQuestaoPorIdUseCase.Executar(id));
        }

        [HttpGet("completas")]
        [ProducesResponseType(typeof(IEnumerable<QuestaoCompletaDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterCompletasPorId([FromQuery]long[] ids, [FromServices] IObterQuestoesCompletaPorIdsUseCase obterQuestoesCompletaPorIdsUseCase)
        {
            return Content(await obterQuestoesCompletaPorIdsUseCase.Executar(ids), "application/json");
        }

        [HttpGet("completas-legado")]
        [ProducesResponseType(typeof(IEnumerable<QuestaoCompletaDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterCompletasPorLegadoId([FromQuery] long[] ids, [FromServices] IObterQuestoesCompletaPorLegadoIdsUseCase obterQuestoesCompletaPorLegadoIdsUseCase)
        {
            return Content(await obterQuestoesCompletaPorLegadoIdsUseCase.Executar(ids), "application/json");
        }
    }
}
