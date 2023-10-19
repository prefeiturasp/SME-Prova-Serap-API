using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/configuracoes")]
    public class ConfiguracaoController : ControllerBase
    {
        [HttpGet("telas-boas-vindas")]
        [ProducesResponseType(typeof(TelaBoasVindasDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterTelasBoasVindas([FromServices] IObterTelasBoasVindasUseCase obterTelasBoasVindasUseCase)
        {
            return Ok(await obterTelasBoasVindasUseCase.Executar());
        }

        [HttpGet("datahora")]
        [ProducesResponseType(typeof(DataHoraServidorDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterDataHoraServidor([FromServices] IObterDataHoraServidorUseCase obterDataHoraServidorUseCase)
        {
            return Ok(await obterDataHoraServidorUseCase.Executar());
        }
        
        [HttpHead("existe-conexao")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult VerificaConexao()
        {
            return Ok(true);
        }
    }
}
