using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Aplicacao.Interfaces.UseCase;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/provas-presenca")]
    public class ProvaPresencaController : ControllerBase
    {
        public ProvaPresencaController()
        {
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 400)]
        [ProducesResponseType(typeof(RetornoBaseDto), 409)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ChaveAutenticacaoApi]
        public async Task<IActionResult> CriarProvaPresenca([FromBody] CriarProvaPresencaDto provaPresencaDto,
                                                    [FromServices] ICriarProvaPresencaUseCase criarProvaPresencaUseCase)
        {
            if (!ModelState.IsValid)
            {
                var retornoDto = new RetornoBaseDto();
                retornoDto.Mensagens = ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)
                                            .ToList();
                return BadRequest(retornoDto);
            }

            try
            {
                await criarProvaPresencaUseCase.Executar(provaPresencaDto);
                return Ok("Solicitação de criação de prova de presença enviada para processamento.");
            }
            catch (NegocioException ex)
            {
                return Conflict(new RetornoBaseDto(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoBaseDto($"Erro interno do servidor: {ex.Message}"));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 400)]
        [ProducesResponseType(typeof(RetornoBaseDto), 404)]
        [ProducesResponseType(typeof(RetornoBaseDto), 409)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ChaveAutenticacaoApi]
        public async Task<IActionResult> AtualizarProvaPresenca(long id, [FromBody] AtualizarProvaPresencaDto provaPresencaDto,
                                                         [FromServices] IAtualizarProvaPresencaUseCase atualizarProvaPresencaUseCase)
        {
            if (id != provaPresencaDto.Id)
            {
                return BadRequest(new RetornoBaseDto("O ID da rota não corresponde ao ID no corpo da requisição."));
            }

            if (!ModelState.IsValid)
            {
                var retornoDto = new RetornoBaseDto();
                retornoDto.Mensagens = ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)
                                            .ToList();
                return BadRequest(retornoDto);
            }

            try
            {
                await atualizarProvaPresencaUseCase.Executar(provaPresencaDto);
                return Ok("Solicitação de atualização de prova de presença enviada para processamento.");
            }
            catch (NegocioException ex)
            {
                if (ex.Message.Contains("não encontrada"))
                {
                    return NotFound(new RetornoBaseDto(ex.Message));
                }
                return Conflict(new RetornoBaseDto(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoBaseDto($"Erro interno do servidor: {ex.Message}"));
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListarProvaPresencaDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ChaveAutenticacaoApi]
        public async Task<IActionResult> ObterProvasPresenca([FromServices] IListarProvaPresencaUseCase listarProvaPresencaUseCase)
        {
            var provas = await listarProvaPresencaUseCase.Executar();
            return Ok(provas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ListarProvaPresencaDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 404)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ChaveAutenticacaoApi]
        public async Task<IActionResult> ObterProvaPresencaPorId(long id, [FromServices] IObterProvaPresencaPorIdUseCase obterProvaPresencaPorIdUseCase)
        {
            var prova = await obterProvaPresencaPorIdUseCase.Executar(id);
            if (prova == null)
            {
                return NotFound(new RetornoBaseDto($"Prova de Presença com ID {id} não encontrada."));
            }
            return Ok(prova);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 400)]
        [ProducesResponseType(typeof(RetornoBaseDto), 404)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ChaveAutenticacaoApi]
        public async Task<IActionResult> DeletarProvaPresenca(long id, [FromServices] IDeletarProvaPresencaUseCase deletarProvaPresencaUseCase)
        {
            if (id <= 0)
            {
                return BadRequest(new RetornoBaseDto("O ID da prova de presença é inválido."));
            }

            try
            {
                await deletarProvaPresencaUseCase.Executar(id);
                return Ok($"Solicitação de exclusão da Prova de Presença com ID {id} enviada para processamento.");
            }
            catch (NegocioException ex)
            {
                if (ex.Message.Contains("não encontrada"))
                {
                    return NotFound(new RetornoBaseDto(ex.Message));
                }
                return BadRequest(new RetornoBaseDto(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoBaseDto($"Erro interno do servidor: {ex.Message}"));
            }
        }
    }
}