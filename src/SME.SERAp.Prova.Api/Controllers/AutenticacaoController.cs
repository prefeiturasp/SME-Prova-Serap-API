using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        [ValidaDto]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(UsuarioAutenticacaoDto), 200)]
        public async Task<IActionResult> Autenticar(AutenticacaoDto autenticacaoDto,
            [FromServices] IAutenticarUsuarioUseCase autenticarUsuarioUseCase)
        {
            return Ok(await autenticarUsuarioUseCase.Executar(autenticacaoDto));
        }

        [HttpPost("revalidar")]
        [ValidaDto]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(UsuarioAutenticacaoDto), 200)]
        public async Task<IActionResult> RevalidarToken([FromServices] IRevalidaTokenJwtUseCase revalidaTokenJwtUseCase,
            [FromBody] RevalidaTokenDto revalidaTokenDto)
        {
            return Ok(await revalidaTokenJwtUseCase.Executar(revalidaTokenDto));
        }

        [Authorize("Bearer")]
        [HttpGet("meus-dados")]
        [ValidaDto]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(MeusDadosRetornoDto), 200)]
        public async Task<IActionResult> Meusdados([FromServices] IObterMeusDadosUseCase obterMeusDadosUseCase)
        {
            return Ok(await obterMeusDadosUseCase.Executar());
        }
    }
}