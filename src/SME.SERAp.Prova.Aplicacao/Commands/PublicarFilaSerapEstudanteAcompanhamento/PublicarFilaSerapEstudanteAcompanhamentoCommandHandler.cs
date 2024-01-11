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
    public class PublicarFilaSerapEstudanteAcompanhamentoCommandHandler : IRequestHandler<PublicarFilaSerapEstudanteAcompanhamentoCommand, bool>
    {
        private readonly IConnectionFactory factory;
        private readonly IMediator mediator;

        public PublicarFilaSerapEstudanteAcompanhamentoCommandHandler(IConnectionFactory factory, IMediator mediator)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Task<bool> Handle(PublicarFilaSerapEstudanteAcompanhamentoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem, Guid.NewGuid());
                var body = Encoding.UTF8.GetBytes(mensagem.ConverterObjectParaJson());
                
                using var conexaoRabbit = factory.CreateConnection();
                using var canal = conexaoRabbit.CreateModel();
                var props = canal.CreateBasicProperties();
                
                props.Persistent = true;
                canal.BasicPublish(ExchangeRabbit.SerapEstudanteAcompanhamento, request.Fila, props, body);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"Erros: PublicarFilaSerapEstudanteAcompanhamentoCommand: Fila -> {request.Fila}", LogNivel.Critico, ex.Message), cancellationToken);
                return Task.FromResult(false);
            }
        }
    }
}
