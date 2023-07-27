using RabbitMQ.Client;
using SME.SERAp.Prova.Dominio.Entidades;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Text;
using Newtonsoft.Json;
using SME.SERAp.Prova.Dominio;
using Microsoft.Extensions.Logging;

namespace SME.SERAp.Prova.Infra.Services
{
    public class ServicoLog : IServicoLog
    {
        private readonly ILogger<ServicoLog> logger;
        private readonly IServicoTelemetria servicoTelemetria;
        private readonly RabbitLogOptions configuracaoRabbitOptions;

        public ServicoLog(IServicoTelemetria servicoTelemetria, RabbitLogOptions configuracaoRabbitOptions, ILogger<ServicoLog> logger)
        {
            this.servicoTelemetria = servicoTelemetria ?? throw new ArgumentNullException(nameof(servicoTelemetria));
            this.configuracaoRabbitOptions = configuracaoRabbitOptions ?? throw new System.ArgumentNullException(nameof(configuracaoRabbitOptions));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Registrar(Exception ex)
        {
            var logMensagem = new LogMensagem("Exception --- ", LogNivel.Critico, ex.Message, ex.StackTrace);
            Registrar(logMensagem);
        }

        public void Registrar(LogNivel nivel, string erro, string observacoes, string stackTrace)
        {
            var logMensagem = new LogMensagem(erro, nivel, observacoes, stackTrace);
            Registrar(logMensagem);
        }

        public void Registrar(string mensagem, Exception ex)
        {
            var logMensagem = new LogMensagem(mensagem, LogNivel.Critico, ex.Message, ex.StackTrace);
            Registrar(logMensagem);
        }

        private void Registrar(LogMensagem log)
        {
            var mensagem = JsonConvert.SerializeObject(log, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var body = Encoding.UTF8.GetBytes(mensagem);

            servicoTelemetria.Registrar(() => PublicarMensagem(body), "RabbitMQ", "Salvar Log Via Rabbit", RotasRabbit.RotaLogs);
        }

        private void PublicarMensagem(byte[] body)
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

                using (var conexaoRabbit = factory.CreateConnection())
                {
                    using (IModel _channel = conexaoRabbit.CreateModel())
                    {
                        var props = _channel.CreateBasicProperties();
                        props.Persistent = true;
                        _channel.BasicPublish(ExchangeRabbit.Logs, RotasRabbit.RotaLogs, props, body);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}


