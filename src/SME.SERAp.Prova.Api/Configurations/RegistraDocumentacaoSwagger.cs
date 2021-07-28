using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SME.SERAp.Prova.Aplicacao;

namespace SME.SERAp.Prova.Api.Configuracoes
{
    public static class RegistraDocumentacaoSwagger
    {
        public static void Registrar(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();

            var mediator = sp.GetService<IMediator>();
            var versaoAtual = mediator.Send(new ObterUltimaVersaoApiQuery()).Result;


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"SGP v1", Version = versaoAtual });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Para autenticação, incluir 'Bearer' seguido do token JWT",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                var requirement = new OpenApiSecurityRequirement();
                c.AddSecurityRequirement(requirement);
            });
        }
    }
}
