using MediatR;
using RabbitMQ.Client;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PublicarFilaSerapCommandHandler : IRequestHandler<PublicarFilaSerapCommand, bool>
    {
        private readonly IConnectionFactory factory;
        private readonly IMediator mediator;

        public PublicarFilaSerapCommandHandler(IConnectionFactory factory, IMediator mediator)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Task<bool> Handle(PublicarFilaSerapCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem, Guid.NewGuid());
                var body = Encoding.UTF8.GetBytes(mensagem.ConverterObjectParaJson());

                using var conexaoRabbit = factory.CreateConnection();
                using var canal = conexaoRabbit.CreateModel();
                var props = canal.CreateBasicProperties();
                
                props.Persistent = true;
                canal.BasicPublish(ExchangeRabbit.Serap, request.Fila, props, body);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"Erros: PublicarFilaSerapCommand: Fila -> {request.Fila}", LogNivel.Critico, ex.Message), cancellationToken);
                return Task.FromResult(false);
            }
        }
    }
}
