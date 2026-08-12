using MediatR;
using SME.SERAp.Prova.Aplicacao.Interfaces.UseCase;
using SME.SERAp.Prova.Aplicacao.Queries.ObterProvaPresencaPorId;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class AtualizarProvaPresencaUseCase : AbstractUseCase, IAtualizarProvaPresencaUseCase
    {
        private readonly IServicoLog servicoLog;

        public AtualizarProvaPresencaUseCase(IMediator mediator, IServicoLog servicoLog) : base(mediator)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<bool> Executar(AtualizarProvaPresencaDto provaPresencaDto)
        {
            try
            {
                var provaExistente = await mediator.Send(new ObterProvaPresencaPorIdQuery(provaPresencaDto.Id));
                if (provaExistente == null)
                {
                    throw new NegocioException($"Prova de Presença com ID {provaPresencaDto.Id} não encontrada para atualização.");
                }

                await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.AtualizarProvaPresenca, provaPresencaDto));

                servicoLog.Registrar(LogNivel.Informacao, $"Solicitação de atualização da Prova de Presença ID {provaPresencaDto.Id} enviada para processamento.", string.Empty, string.Empty);
                return true;
            }
            catch (NegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(LogNivel.Critico, $"Erro ao enviar solicitação de atualização da Prova de Presença ID {provaPresencaDto.Id}: {ex.Message}", string.Empty, ex.StackTrace);
                throw;
            }
        }
    }
}