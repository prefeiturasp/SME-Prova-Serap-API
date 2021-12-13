using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/downloads")]

    public class DownloadController : ControllerBase
    {
        public DownloadController()
        {

        }

        [HttpPost()]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        //[Authorize("Bearer")]
        public async Task<IActionResult> IncluirDownloadProvaAluno(DownloadProvaAlunoDto downloadProvaAlunoDto, [FromServices] IIncluirDownloadProvaAlunoUseCase incluirDownloadProvaAlunoUseCase)
        {
            return Ok(await incluirDownloadProvaAlunoUseCase.Executar(downloadProvaAlunoDto));
        }

        [HttpDelete()]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        //[Authorize("Bearer")]
        public async Task<IActionResult> ExcluidDownloads(int[] ids, [FromServices] IExcluirDownloadProvaAlunoUseCase excluirDownloadsProvaAlunoUseCase)
        {
            return Ok(await excluirDownloadsProvaAlunoUseCase.Executar(ids));
        }


    }
}
