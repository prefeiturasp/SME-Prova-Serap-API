using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/downloads")]

    public class DownloadController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirDownloadProvaAluno(DownloadProvaAlunoDto downloadProvaAlunoDto, [FromServices] IIncluirDownloadProvaAlunoUseCase incluirDownloadProvaAlunoUseCase)
        {
            return Ok(await incluirDownloadProvaAlunoUseCase.Executar(downloadProvaAlunoDto));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ChaveAutenticacaoApi]
        public async Task<IActionResult> ExcluirDownloads(Guid[] codigos, [FromServices] IExcluirDownloadProvaAlunoUseCase excluirDownloadsProvaAlunoUseCase)
        {
            return Ok(await excluirDownloadsProvaAlunoUseCase.Executar(codigos));
        }
    }
}
