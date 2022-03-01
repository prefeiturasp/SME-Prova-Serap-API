using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/provasAdm")]
    public class ProvaAdmController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<Dominio.Prova>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvas([FromQuery] ProvaAdmFiltroDto paginacaoFiltroDto, [FromServices] IObterProvaAreaAdministrativoUseCase obterProvaAreaAdministrativoUseCase)
        {
            return Ok(await obterProvaAreaAdministrativoUseCase.Executar(paginacaoFiltroDto));
        }
    }
}
