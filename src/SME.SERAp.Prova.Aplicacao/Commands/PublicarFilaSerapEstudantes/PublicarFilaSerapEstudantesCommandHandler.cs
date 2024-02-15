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
    public class PublicarFilaSerapEstudantesCommandHandler : IRequestHandler<PublicarFilaSerapEstudantesCommand, bool>
    {
        private readonly IConnection connectionRabbit;
        private readonly IMediator mediator;

        public PublicarFilaSerapEstudantesCommandHandler(IConnection connectionRabbit, IMediator mediator)
        {
            this.connectionRabbit = connectionRabbit ?? throw new ArgumentNullException(nameof(connectionRabbit));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Task<bool> Handle(PublicarFilaSerapEstudantesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new MensagemRabbit(request.Mensagem, Guid.NewGuid());
                var body = Encoding.UTF8.GetBytes(mensagem.ConverterObjectParaJson());

                using var canal = connectionRabbit.CreateModel();
                var props = canal.CreateBasicProperties();

                props.Persistent = true;
                canal.BasicPublish(ExchangeRabbit.SerapEstudante, request.Fila, props, body);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"Erros: PublicarFilaSerapEstudantesCommand -- Estudantes: Fila -> {request.Fila}", LogNivel.Critico, ex.Message), cancellationToken);
                return Task.FromResult(false);
            }
        }
    }
}
