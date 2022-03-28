using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/admin/provas")]
    public class AdminProvaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvas([FromQuery] ProvaAdmFiltroDto paginacaoFiltroDto, [FromServices] IObterProvaAreaAdministrativoUseCase obterProvaAreaAdministrativoUseCase)
        {
            return Ok(await obterProvaAreaAdministrativoUseCase.Executar(paginacaoFiltroDto));
        }

        [HttpGet("{provaId}/resumos")]
        [ProducesResponseType(typeof(IEnumerable<ProvaResumoAdministrativoRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvasResumo(long provaId, [FromServices] IObterProvaResumoAreaAdministrativoUseCase obterProvaResumoAreaAdministrativoUseCase)
        {
            return Ok(await obterProvaResumoAreaAdministrativoUseCase.Executar(provaId));
        }

        [HttpGet("{provaId}/cadernos")]
        [ProducesResponseType(typeof(ProvaCadernoRetornoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvasCaderno(long provaId, [FromServices] IObterProvaCadernosAreaAdministrativoUseCase obterProvaCadernosAreaAdministrativoUseCase)
        {
            return Ok(await obterProvaCadernosAreaAdministrativoUseCase.Executar(provaId));
        }

        [HttpGet("{provaId}/cadernos/{caderno}/resumos")]
        [ProducesResponseType(typeof(IEnumerable<ProvaResumoAdministrativoRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvasResumoPorCaderno(long provaId, string caderno, [FromServices] IObterProvaResumoAreaAdministrativoUseCase obterProvaResumoAreaAdministrativoUseCase)
        {
            return Ok(await obterProvaResumoAreaAdministrativoUseCase.Executar(provaId, caderno));
        }

        [HttpGet("{provaId}/questoes/{questaoId}/detalhes")]
        [ProducesResponseType(typeof(QuestaoDetalheResumoRetornoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterQuestaoDetalhe(long provaId, long questaoId, [FromServices] IObterQuestaoDetalhesResumidoAreaAdministrativoUseCase obterQuestaoDetalhesResumidoAreaAdministrativoUseCase)
        {
            return Ok(await obterQuestaoDetalhesResumidoAreaAdministrativoUseCase.Executar(provaId, questaoId));
        }
    }
}
