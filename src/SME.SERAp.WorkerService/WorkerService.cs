using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sentry;
using SME.Background.Core;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra.Utilitarios;
using SME.SERAp.Prova.IoC;
using SME.SERAp.Prova.IoC.Extensions;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Worker.Service
{
    public class WorkerService : IHostedService
    {
        private static Servidor<Background.Hangfire.Worker> HangfireWorkerService;
        private string ipLocal;

        protected string IPLocal
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ipLocal))
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipLocal = ip.ToString();
                        }
                    }

                    if (string.IsNullOrWhiteSpace(ipLocal))
                        ipLocal = "127.0.0.1";
                }

                return ipLocal;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            SentrySdk.AddBreadcrumb($"[SME SERAp] Serviço Background iniciado no ip: {IPLocal}", "Service Life cycle");
            HangfireWorkerService.Registrar();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            HangfireWorkerService.Dispose();
            SentrySdk.AddBreadcrumb($"[SME SERAp] Serviço Background finalizado no ip: {IPLocal}", "Service Life cycle");
            return Task.CompletedTask;
        }

        internal static void Configurar(IConfiguration config, IServiceCollection services)
        {
            HangfireWorkerService = new Servidor<Background.Hangfire.Worker>(new Background.Hangfire.Worker(config, services, config.GetConnectionString("ApiSerap")));
        }

        internal static void ConfigurarDependencias(IConfiguration configuration, IServiceCollection services)
        {
            services.AddPolicies();
            RegistraDependenciasWorkerServices.Registrar(services);
            RegistraMapeamentos.Registrar();
            Orquestrador.Inicializar(services.BuildServiceProvider());
        }

        internal static void ConfiguraVariaveisAmbiente(IServiceCollection services, IConfiguration configuration)
        {
            var configuracaoRabbitOptions = new ConfiguracaoRabbitOptions();
            configuration.GetSection(nameof(ConfiguracaoRabbitOptions)).Bind(configuracaoRabbitOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(configuracaoRabbitOptions);
        }        
    }
}