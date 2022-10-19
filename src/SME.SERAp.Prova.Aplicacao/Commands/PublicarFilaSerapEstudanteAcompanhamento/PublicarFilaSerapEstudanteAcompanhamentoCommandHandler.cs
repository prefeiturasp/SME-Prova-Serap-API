using MediatR;
using RabbitMQ.Client;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PublicarFilaSerapEstudanteAcompanhamentoCommandHandler : IRequestHandler<PublicarFilaSerapEstudanteAcompanhamentoCommand, bool>
    {

        private readonly IConnection connectionRabbit;
        private readonly IMediator mediator;

        public PublicarFilaSerapEstudanteAcompanhamentoCommandHandler(IConnection connectionRabbit)
        {
            this.connectionRabbit = connectionRabbit ?? throw new ArgumentNullException(nameof(connectionRabbit));
        }

        public Task<bool> Handle(PublicarFilaSerapEstudanteAcompanhamentoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem, Guid.NewGuid());

                var mensagemJson = JsonSerializer.Serialize(mensagem);
                var body = Encoding.UTF8.GetBytes(mensagemJson);

                using (IModel canal = connectionRabbit.CreateModel())
                {
                    var props = canal.CreateBasicProperties();
                    props.Persistent = true;
                    canal.BasicPublish(ExchangeRabbit.SerapEstudanteAcompanhamento, request.Fila, props, body);
                }

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"Erros: PublicarFilaSerapEstudanteAcompanhamentoCommand: Fila -> {request.Fila}", LogNivel.Critico, ex.Message));
                return Task.FromResult(false);
            }
        }
    }
}
