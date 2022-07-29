using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SME.SERAp.Prova.Api.Filtros;
using SME.SERAp.Prova.Api.Middlewares;
using SME.SERAp.Prova.Infra.Interfaces;

namespace SME.SERAp.Prova.Api.Configuracoes
{
    public static class RegistraMvc
    {
        public static void Registrar(IServiceCollection services, ServiceProvider serviceProvider)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var mediator = serviceProvider.GetService<IMediator>();
            var serviceLog = serviceProvider.GetService<IServicoLog>();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;                
                options.Filters.Add(new ValidaDtoAttribute());
                options.Filters.Add(new FiltroExcecoesAttribute(mediator, serviceLog));
                

            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}
