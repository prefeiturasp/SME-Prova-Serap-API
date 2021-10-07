using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/provas")]
    public class ProvaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ObterProvasRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvas([FromServices] IObterProvasAreaEstudanteUseCase obterProvasAreaEstudanteUseCase)
        {
            return Ok(await obterProvasAreaEstudanteUseCase.Executar());
        }

        [HttpGet("{id}/detalhes-resumido")]
        [ProducesResponseType(typeof(IEnumerable<ProvaDetalheResumidoRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterDetalhesResumido(long id, [FromServices] IObterProvaDetalhesResumidoUseCase obterProvaDetalhesResumidoUseCase)
        {
            return Ok(await obterProvaDetalhesResumidoUseCase.Executar(id));
        }

        [HttpGet("{provaId}/status-aluno")]
        [ProducesResponseType(typeof(ProvaAlunoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvaStatusDoAluno(long provaId, [FromServices] IObterProvaAlunoUseCase obterProvaAlunoUseCase)
        {
            return Ok(await obterProvaAlunoUseCase.Executar(provaId));
        }

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
