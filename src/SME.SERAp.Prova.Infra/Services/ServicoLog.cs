using RabbitMQ.Client;
using SME.SERAp.Prova.Dominio.Entidades;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra.Services
{
    public class ServicoLog : IServicoLog
    {
        private readonly IServicoTelemetria servicoTelemetria;
        private readonly RabbitLogOptions configuracaoRabbitOptions;
        public ServicoLog(IServicoTelemetria servicoTelemetria, RabbitLogOptions configuracaoRabbitOptions)
        {
            this.servicoTelemetria = servicoTelemetria ?? throw new ArgumentNullException(nameof(servicoTelemetria));
            this.configuracaoRabbitOptions = configuracaoRabbitOptions ?? throw new System.ArgumentNullException(nameof(configuracaoRabbitOptions));
        }

        public void Registrar(Exception ex)
        {
            LogMensagem logMensagem = new LogMensagem("Exception --- ", LogNivel.Critico, ex.Message, ex.StackTrace);
            Registrar(logMensagem);
        }

        public void Registrar(LogNivel nivel, string erro, string observacoes, string stackTrace)
        {
            LogMensagem logMensagem = new LogMensagem(erro,nivel, observacoes, stackTrace);
            Registrar(logMensagem);

        }

        public void Registrar(string mensagem, Exception ex )
        {
            LogMensagem logMensagem = new LogMensagem(mensagem, LogNivel.Critico, ex.Message, ex.StackTrace);

            Registrar(logMensagem);
        }
        private void Registrar(LogMensagem log)
        {
            try
            {
                var mensagem = JsonConvert.SerializeObject(log, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore

                });

                var body = Encoding.UTF8.GetBytes(mensagem);

                servicoTelemetria.Registrar(() => PublicarMensagem(body), "RabbitMQ", "Salvar Log Via Rabbit", RotasRabbit.RotaLogs);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void PublicarMensagem(byte[] body)
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

                    _channel.BasicPublish(ExchangeRabbit.Logs, RotasRabbit.RotaLogs, props, body);
                }
            }
        }
    }
}


