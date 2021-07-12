using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sentry;
using SME.SERAp.Prova.Api.Middlewares;

namespace SME.SERAp.Prova.Api.Configuracoes
{
    public static class RegistrarMvc
    {
        public static void Registrar(IServiceCollection services, SentryOptions sentryOptions)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add(new FiltroExcecoesAttribute(sentryOptions));

            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}
