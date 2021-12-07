using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SME.SERAp.Prova.Aplicacao.Pipelines;
using System;

namespace SME.SERAp.Prova.IoC
{
    public static class RegistraMediatr
    {
        public static void AdicionarMediatr(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SME.SERAp.Prova.Aplicacao");
            services.AddMediatR(assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacoesPipeline<,>));
        }
    }
}
