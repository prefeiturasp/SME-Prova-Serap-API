using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.UseCase;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/provas-tai")]
    public class ProvaTaiController : ControllerBase
    {
        public ProvaTaiController() { }


        [HttpGet("existe-conexao-R")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> verificaConexaoR(IVerificaConexaoComServicoRUseCase verificaConexaoComServicoRUseCase)
        {
            return Ok(await verificaConexaoComServicoRUseCase.Executar());
        }


        [HttpPost("{provaId}/iniciar-prova")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> IniciarProva(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto, [FromServices] IIniciarProvaTaiUseCase iniciarProvaTaiUseCase)
        {
            return Ok(await iniciarProvaTaiUseCase.Executar(provaId, provaAlunoStatusDto));
        }

        [HttpPost("{provaId}/finalizar-prova")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> FinalizarProva(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto, [FromServices] IFinalizarProvaTaiUseCase finalizarProvaTaiUseCase)
        {
            return Ok(await finalizarProvaTaiUseCase.Executar(provaId, provaAlunoStatusDto));
        }

        [HttpPost("{provaId}/obter-questao")]
        [ProducesResponseType(typeof(QuestaoCompletaDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterQuestao(long provaId, [FromServices] IObterQuestaoProvaTaiUseCase obterQuestaoProvaTaiUseCase)
        {
            var questaoCompletaJson = await obterQuestaoProvaTaiUseCase.Executar(provaId);
            return Content(questaoCompletaJson, "application/json");
        }
    }
}
