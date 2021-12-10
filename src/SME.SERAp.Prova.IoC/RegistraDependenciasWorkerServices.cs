using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RabbitMQ.Client;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.Pipelines;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Contexto;
using SME.SERAp.Prova.Infra.Interfaces;
using SME.SERAp.Prova.IoC;
using SME.SERAp.Prova.IoC.Extensions;
using System;

namespace SME.SERAp.Prova.IoC
{
    public static class RegistraDependenciasWorkerServices
    {
        public static void Registrar(IServiceCollection services)
        {
            RegistrarMediator(services);

            ResgistraDependenciaHttp(services);
            RegistrarRepositorios(services);
            RegistrarContextos(services);
            RegistrarComandos(services);
            RegistrarConsultas(services);
            RegistrarServicos(services);
            RegistrarCasosDeUso(services);
        }

        private static void RegistrarMediator(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SME.SERAp.Prova.Aplicacao");
            services.AddMediatR(assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacoesPipeline<,>));
        }
        private static void RegistrarRabbit(IServiceCollection services)
        {
            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__HostName"),
                UserName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__UserName"),
                Password = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Password"),
                VirtualHost = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Virtualhost")
            };

            var conexaoRabbit = factory.CreateConnection();
            IModel canalRabbit = conexaoRabbit.CreateModel();
            services.AddSingleton(conexaoRabbit);
            services.AddSingleton(canalRabbit);
        }

        private static void RegistrarComandos(IServiceCollection services){}

        private static void RegistrarConsultas(IServiceCollection services){}

        private static void RegistrarContextos(IServiceCollection services){}

        private static void RegistrarRepositorios(IServiceCollection services){}

        private static void RegistrarServicos(IServiceCollection services){}

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScopedWorkerService<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase, IniciarProcessoFinalizarProvasAutomaticamenteUseCase>();
        }

        private static void ResgistraDependenciaHttp(IServiceCollection services){}
    }
}
