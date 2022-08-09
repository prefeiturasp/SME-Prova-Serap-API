using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.ImagemLog;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/imagemlog")]
    public class ImagemLogController : ControllerBase
    {
        [HttpPost]
        [ChaveAutenticacaoApi]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ValidaDto]
        public async Task<IActionResult> LogarNecessidadeDeUsoDaUrl([FromBody] ImagemLogDto input, 
            [FromServices] IImagemLogUseCase imagemLogUseCase)
        {
            await imagemLogUseCase.Executar(input);
            return Ok();
        }
    }
}
