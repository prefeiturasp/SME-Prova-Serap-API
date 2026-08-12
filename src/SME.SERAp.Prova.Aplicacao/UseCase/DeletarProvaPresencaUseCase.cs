using MediatR;
using SME.SERAp.Prova.Aplicacao.Interfaces.UseCase;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class DeletarProvaPresencaUseCase : AbstractUseCase, IDeletarProvaPresencaUseCase
    {
        private readonly IServicoLog servicoLog;

        public DeletarProvaPresencaUseCase(IMediator mediator, IServicoLog servicoLog) : base(mediator)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<bool> Executar(long id)
        {
            if (id <= 0)
            {
                servicoLog.Registrar(LogNivel.Negocio, $"ID da Prova de Presença para exclusão é inválido (menor ou igual a zero).", string.Empty, string.Empty);
                throw new NegocioException("ID da Prova de Presença para exclusão é inválido.");
            }

            try
            {
                var dto = new DeletarProvaPresencaDto { Id = id };

                var dtoAsJson = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.DeletarProvaPresenca, dtoAsJson));

                servicoLog.Registrar(LogNivel.Informacao, $"Solicitação de exclusão da Prova de Presença com ID {id} enviada para processamento.", string.Empty, string.Empty);
                return true;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(LogNivel.Critico, $"Erro ao enviar solicitação de exclusão da Prova de Presença com ID {id} para o RabbitMQ: {ex.Message}", string.Empty, ex.StackTrace);
                throw;
            }
        }
    }
}