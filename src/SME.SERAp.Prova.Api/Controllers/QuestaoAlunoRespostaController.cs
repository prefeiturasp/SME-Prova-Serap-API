using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/questoes/respostas")]
    public class QuestaoAlunoRespostaController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        [ValidaDto]
        public async Task<IActionResult> SalvarResposta([FromBody] QuestaoAlunoRespostaIncluirDto questaoAlunoRespostaIncluirDto,
            [FromServices] IIncluirQuestaoAlunoRespostaUseCase incluirQuestaoAlunoRespostaUseCase)
        {
            DateTime horaDataResposta = new(questaoAlunoRespostaIncluirDto.DataHoraRespostaTicks);

            return Ok(await incluirQuestaoAlunoRespostaUseCase.Executar(
                questaoAlunoRespostaIncluirDto.QuestaoId,
                questaoAlunoRespostaIncluirDto.AlternativaId,
                questaoAlunoRespostaIncluirDto.Resposta, horaDataResposta,
                questaoAlunoRespostaIncluirDto.TempoRespostaAluno));
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
