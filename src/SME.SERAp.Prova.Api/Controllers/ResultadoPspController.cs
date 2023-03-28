using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [ChaveAutenticacaoApi]
    [Route("/api/v1/resultados-psp")]
    public class ResultadoPspController : Controller
    {
        public ResultadoPspController()
        {

        }

        [HttpPost("upload-arquivo")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [DisableRequestSizeLimit]        
        public async Task<IActionResult> UploadArquivoResultadosPsp([FromForm] IFormFile arquivo, 
                                                                    [FromForm] ImportArquivoResultadoPspDto arquivoResultadoDto,
                                                                    [FromServices] IImportarArquivoResultadoPspUseCase importarArquivoResultadoPspUseCase)
        {
            return Ok(await importarArquivoResultadoPspUseCase.Executar(arquivo, arquivoResultadoDto));
        }

        [HttpGet("processo/{processoId}/tipo-resultado/{tipoResultado}/tratar")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]        
        public async Task<IActionResult> TratarImportacao(long processoId, int tipoResultado,
                                                          [FromServices] ITratarImportacaoResultadoPspUseCase tratarImportacaoResultadoPspUseCase)
        {
            return Ok(await tratarImportacaoResultadoPspUseCase.Executar(processoId, tipoResultado));
        }

        [HttpGet("processo/{processoId}/baixar-arquivo")]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        public async Task<IActionResult> BaixarArquivoResultadoPsp(long processoId, [FromServices] IBaixarArquivoResultadoPspUseCase baixarArquivoResultadoPspUseCase)
        {
            var (arquivo, nomeArquivo) = await baixarArquivoResultadoPspUseCase.Executar(processoId);
            return File(arquivo, "application/csv", nomeArquivo);
        }
    }
}
