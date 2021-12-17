using MediatR;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using Sentry;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PublicarFilaSerapEstudantesCommandHandler : IRequestHandler<PublicarFilaSerapEstudantesCommand, bool>
    {
        private readonly IConnection connectionRabbit;

        public PublicarFilaSerapEstudantesCommandHandler(IConnection connectionRabbit)
        {
            this.connectionRabbit = connectionRabbit ?? throw new ArgumentNullException(nameof(connectionRabbit));
        }

        public Task<bool> Handle(PublicarFilaSerapEstudantesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem, Guid.NewGuid());

                var mensagemJson = JsonSerializer.Serialize(mensagem);
                var body = Encoding.UTF8.GetBytes(mensagemJson);

                using(IModel canal = connectionRabbit.CreateModel())
                {
                    var props = canal.CreateBasicProperties();
                    props.Persistent = true;
                    canal.BasicPublish(ExchangeRabbit.SerapEstudante, request.Fila, props, body);
                }
                
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                SentrySdk.AddBreadcrumb($"Erros: PublicarFilaSerapEstudantesCommand", null, null, null, BreadcrumbLevel.Error);
                SentrySdk.CaptureMessage($"SERAp Estudantes: Fila -> {request.Fila}", SentryLevel.Error);
                SentrySdk.CaptureException(ex);
                return Task.FromResult(false);
            }
        }
    }
}
