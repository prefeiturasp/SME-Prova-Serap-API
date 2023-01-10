using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/resultados-psp")]
    public class ResultadoPspController : Controller
    {
        public ResultadoPspController()
        {

        }

        [HttpPost("upload-arquivo")]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [DisableRequestSizeLimit]
        [RequestSizeLimit(268435456)]
        [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
        public async Task<IActionResult> UploadArquivoResultadosPsp([FromForm] IFormFile arquivo, 
                                                                    [FromForm] ImportArquivoResultadoPspDto arquivoResultadoDto,
                                                                    [FromServices] IImportarArquivoResultadoPspUseCase importarArquivoResultadoPspUseCase)
        {
            return Ok(await importarArquivoResultadoPspUseCase.Executar(arquivo, arquivoResultadoDto));
        }
    }
}
