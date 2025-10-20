using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.ResultadoPsp;
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadArquivoResultadosPsp(
                                    [FromForm] UploadArquivoResultadoPspRequest request,
                                    [FromServices] IImportarArquivoResultadoPspUseCase importarArquivoResultadoPspUseCase)
        {
            var dto = new ImportArquivoResultadoPspDto
            {
                Arquivo = request.Arquivo,
                NomeArquivo = request.NomeArquivo
            };

            return Ok(await importarArquivoResultadoPspUseCase.Executar(dto));
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