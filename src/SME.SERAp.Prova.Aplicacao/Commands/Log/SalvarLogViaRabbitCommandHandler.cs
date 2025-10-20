using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SME.SERAp.Prova.Infra;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Commands.Log
{
    public class SalvarLogViaRabbitCommandHandler : IRequestHandler<SalvarLogViaRabbitCommand, bool>
    {
        private readonly RabbitLogOptions configuracaoRabbitOptions;
        private readonly IServicoTelemetria servicoTelemetria;

        public SalvarLogViaRabbitCommandHandler(RabbitLogOptions configuracaoRabbitOptions, IServicoTelemetria servicoTelemetria)
        {
            this.configuracaoRabbitOptions = configuracaoRabbitOptions ?? throw new ArgumentNullException(nameof(configuracaoRabbitOptions));
            this.servicoTelemetria = servicoTelemetria ?? throw new ArgumentNullException(nameof(servicoTelemetria));
        }

        public Task<bool> Handle(SalvarLogViaRabbitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mensagem = new LogMensagem(request.Mensagem,
                    request.Nivel.ToString(),
                    request.Observacao,
                    request.Projeto,
                    request.Rastreamento,
                    request.ExcecaoInterna);

                var body = Encoding.UTF8.GetBytes(mensagem.ConverterObjectParaJson());

                servicoTelemetria.Registrar(() => PublicarMensagemAsync(body).GetAwaiter().GetResult(), "RabbitMQ", "Salvar Log Via Rabbit", RotasRabbit.RotaLogs);

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        private async Task PublicarMensagemAsync(byte[] body)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = configuracaoRabbitOptions.HostName,
                    UserName = configuracaoRabbitOptions.UserName,
                    Password = configuracaoRabbitOptions.Password,
                    VirtualHost = configuracaoRabbitOptions.VirtualHost
                };

                using var conexaoRabbit = await factory.CreateConnectionAsync();
                using var channel = await conexaoRabbit.CreateChannelAsync();

                var props = new BasicProperties
                {
                    Persistent = true
                };

                await channel.BasicPublishAsync(
                    ExchangeRabbit.Logs,
                    RotasRabbit.RotaLogs,
                    true,
                    props,
                    body
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class LogMensagem
    {
        public LogMensagem(string mensagem, string nivel, string observacao, string projeto, string rastreamento, string excecaoInterna)
        {
            Mensagem = mensagem;
            Nivel = nivel;
            Observacao = observacao;
            Projeto = projeto;
            Rastreamento = rastreamento;
            ExcecaoInterna = excecaoInterna;
            DataHora = DateTime.Now;
        }

        public string Mensagem { get; set; }
        public string Nivel { get; set; }
        public string Observacao { get; set; }
        public string Projeto { get; set; }
        public string Rastreamento { get; set; }
        public string ExcecaoInterna { get; set; }
        public DateTime DataHora { get; set; }
    }
}