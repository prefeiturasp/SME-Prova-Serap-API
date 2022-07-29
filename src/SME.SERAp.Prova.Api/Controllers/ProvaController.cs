using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/provas")]
    public class ProvaController : ControllerBase
    {
        public ProvaController()
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ObterProvasRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
      //  [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvas([FromServices] IObterProvasAreaEstudanteUseCase obterProvasAreaEstudanteUseCase)
        {
            return Ok(await obterProvasAreaEstudanteUseCase.Executar());
        }

        [HttpGet("finalizadas")]
        [ProducesResponseType(typeof(IEnumerable<ObterProvasAnterioresRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvasAnteriores([FromServices] IObterProvasAnterioresAreaEstudanteUseCase obterProvasAnterioresAreaEstudanteUseCase)
        {
            return Ok(await obterProvasAnterioresAreaEstudanteUseCase.Executar());
        }

        [HttpGet("{id}/detalhes-resumido")]
        [ProducesResponseType(typeof(IEnumerable<ProvaDetalheResumidoRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterDetalhesResumido(long id, [FromServices] IObterProvaDetalhesResumidoUseCase obterProvaDetalhesResumidoUseCase)
        {
            return Ok(await obterProvaDetalhesResumidoUseCase.Executar(id));
        }

        [HttpGet("{id}/detalhes-resumido-caderno/{caderno}")]
        [ProducesResponseType(typeof(IEnumerable<ProvaDetalheResumidoCadernoRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterDetalhesResumidoCaderno(long id, string caderno, [FromServices] IObterProvaDetalhesResumidoCadernoUseCase obterProvaDetalhesResumidoCadernoUseCase)
        {
            return Ok(await obterProvaDetalhesResumidoCadernoUseCase.Executar(id, caderno));
        }

        [HttpGet("{provaId}/status-aluno")]
        [ProducesResponseType(typeof(ProvaAlunoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
      // [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvaStatusDoAluno(long provaId, [FromServices] IObterProvaAlunoUseCase obterProvaAlunoUseCase)
        {
            return Ok(await obterProvaAlunoUseCase.Executar(provaId));
        }

        [HttpPost("{provaId}/status-aluno")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
     //   [Authorize("Bearer")]
        public async Task<IActionResult> SalvarProvaStatusDoAluno(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto, [FromServices] IIncluirProvaAlunoUseCase incluirProvaAlunoUseCase)
        {
            return Ok(await incluirProvaAlunoUseCase.Executar(provaId, provaAlunoStatusDto));
        }


        [HttpGet]
        [ProducesResponseType(typeof(QuestaoAlunoRespostaConsultarDto), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        [Route("{provaId}/respostas")]
        public async Task<IActionResult> ObterRespostaPorProvaAluno(long provaId, [FromServices] IObterRespostasAlunoPorProvaIdUseCase obterRespostasAlunoPorProvaIdUseCase)
        {
            return Ok(await obterRespostasAlunoPorProvaIdUseCase.Executar(provaId));
        }
    }
}
