﻿using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> ObterUltimaVersaoApp([FromServices] IObterVersaoAppUseCase obterUltimaVersaoUseCase)
        {
            return Ok(await obterUltimaVersaoUseCase.Executar());
        }
    }
}
