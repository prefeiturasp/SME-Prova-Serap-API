using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        [Authorize("Bearer")]
        [HttpPost("preferencias")]
        [ValidaDto]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> SalvarPreferencias(PreferenciaUsuarioDto preferenciaUsuarioDto,
            [FromServices] IIncluirPreferenciasUsuarioUseCase incluirPreferenciasUsuarioUseCase)
        {
            return Ok(await incluirPreferenciasUsuarioUseCase.Executar(preferenciaUsuarioDto));
        }
    }
}