using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PublicarFilaSerapEstudantesCommandHandler : IRequestHandler<PublicarFilaSerapEstudantesCommand, bool>
    {
        private readonly IConnection connectionRabbit;
        private readonly IMediator mediator;

        public PublicarFilaSerapEstudantesCommandHandler(IConnection connectionRabbit, IMediator mediator)
        {
            this.connectionRabbit = connectionRabbit ?? throw new ArgumentNullException(nameof(connectionRabbit));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(PublicarFilaSerapEstudantesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem, Guid.NewGuid());
                var body = Encoding.UTF8.GetBytes(mensagem.ConverterObjectParaJson());

                await using var canal = await connectionRabbit.CreateChannelAsync(null, cancellationToken);

                var props = new BasicProperties
                {
                    Persistent = true
                };

                await canal.BasicPublishAsync(
                    ExchangeRabbit.SerapEstudante,
                    request.Fila,
                    true,
                    props,
                    body,
                    cancellationToken
                );
               
                return true;
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"Erros: PublicarFilaSerapEstudantesCommand -- Estudantes: Fila -> {request.Fila}", LogNivel.Critico, ex.Message), cancellationToken);

                return false;
            }
        }
    }
}