using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/admin/autenticacao")]
    public class AdminAutenticacaoController : ControllerBase
    {
        [HttpPost]
        [ValidaDto]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(UsuarioAutenticacaoDto), 200)]
        public async Task<IActionResult> Autenticar([FromServices] IAutenticarUsuarioAdmUseCase autenticarUsuarioAdmUseCase,
           [FromBody] AutenticacaoAdmDto autenticacaoDto)
        {
            return Ok(await autenticarUsuarioAdmUseCase.Executar(autenticacaoDto));
        }

        [HttpPost("validar")]
        [ValidaDto]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(UsuarioAutenticacaoDto), 200)]
        public async Task<IActionResult> Validar([FromServices] IAutenticarUsuarioValidarAdmUseCase autenticarUsuarioValidarAdmUseCase,
           [FromBody] string codigo)
        {
            return Ok(await autenticarUsuarioValidarAdmUseCase.Executar(codigo));
        }

        [HttpPost("revalidar")]
        [ValidaDto]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(UsuarioAutenticacaoDto), 200)]
        public async Task<IActionResult> Revalidar([FromServices] IRevalidaTokenJwtAdmUseCase revalidaTokenJwtAdmUseCase,
            [FromBody] RevalidaTokenDto revalidaTokenDto)
        {
            return Ok(await revalidaTokenJwtAdmUseCase.Executar(revalidaTokenDto));
        }
    }
}