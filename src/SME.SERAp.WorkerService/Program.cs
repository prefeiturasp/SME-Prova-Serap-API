﻿using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SME.Background.Core;
using SME.Background.Hangfire;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.IoC;
using SME.SGP.Background;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Worker.Service
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var asService = !(Debugger.IsAttached || args.Contains("--console"));

            var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddEnvironmentVariables();
            })
            .ConfigureLogging((context, logging) =>
            {
                logging.AddConfiguration(context.Configuration);
                logging.AddSentry();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<WorkerService>();
                WorkerService.ConfigurarDependencias(hostContext.Configuration, services);
                WorkerService.Configurar(hostContext.Configuration, services);
                WorkerService.ConfiguraVariaveisAmbiente(services, hostContext.Configuration);

                services.AddApplicationInsightsTelemetryWorkerService(hostContext.Configuration.GetValue<string>("ApplicationInsights__InstrumentationKey"));

                var provider = services.BuildServiceProvider();
                var serviceProvider = services.BuildServiceProvider();

                Orquestrador.Inicializar(serviceProvider);
                Orquestrador.Registrar(new Processor(hostContext.Configuration, "ApiSerap"));
                RegistraDependenciasWorkerServices.Registrar(services);
                RegistraServicosRecorrentes.Registrar();

                var telemetryConfiguration = new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration(hostContext.Configuration.GetValue<string>("ApplicationInsights:InstrumentationKey"));

                var telemetryClient = new TelemetryClient(telemetryConfiguration);

                DapperExtensionMethods.Init(telemetryClient);

                services.AddMemoryCache();

            });

            builder.UseEnvironment(asService ? EnvironmentName.Production : EnvironmentName.Development);

            if (asService)
            {
                await builder.Build().RunAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }
        }
    }
}