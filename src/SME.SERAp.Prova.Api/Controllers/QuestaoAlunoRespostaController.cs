using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/questoes/respostas")]
    public class QuestaoAlunoRespostaController : ControllerBase
    {
        [HttpPost]
        [ChaveAutenticacaoApi]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ValidaDto]
        [Route("sincronizar")]
        public async Task<IActionResult> SincronizarResposta([FromBody] List<QuestaoAlunoRespostaSincronizarDto> listaquestaoAlunoRespostaSincronizarDto, 
            [FromServices] ISincronizarQuestaoAlunoRespostaUseCase sincronizarQuestaoAlunoRespostaUseCase)
        {
            return Ok(await sincronizarQuestaoAlunoRespostaUseCase.Executar(listaquestaoAlunoRespostaSincronizarDto));
        }

        [HttpGet]
        [ProducesResponseType(typeof(QuestaoAlunoRespostaConsultarDto), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        [Route("/api/v1/questoes/{questaoId}/respostas")]        
        public async Task<IActionResult> ObterRespostaPorQuestaoAluno(long questaoId, [FromServices] IObterQuestaoAlunoRespostaPorQuestaoIdUseCase obterQuestaoAlunoRespostaPorQuestaoIdUseCase)
        {
            return Ok(await obterQuestaoAlunoRespostaPorQuestaoIdUseCase.Executar(questaoId));
        }
    }
}
