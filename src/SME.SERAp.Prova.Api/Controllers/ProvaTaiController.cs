using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Prova;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/provas-tai")]
    public class ProvaTaiController : ControllerBase
    {
        public ProvaTaiController(){}

        [HttpPost("{provaId}/status-aluno")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> SalvarProvaStatusDoAluno(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto, [FromServices] IIncluirProvaAlunoUseCase incluirProvaAlunoUseCase)
        {
            return Ok(await incluirProvaAlunoUseCase.Executar(provaId, provaAlunoStatusDto));
        }
    }
}
