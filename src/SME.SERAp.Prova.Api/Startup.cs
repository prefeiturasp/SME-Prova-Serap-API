using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prometheus;
using Sentry;
using SME.SERAp.Prova.Api.Configuracoes;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.IoC;
using System.IO.Compression;

namespace SME.SERAp.Prova.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SME.SERAp.Prova.Api", Version = "v1" });
            });


            var jwtVariaveis = new JwtOptions();
            Configuration.GetSection(nameof(JwtOptions)).Bind(jwtVariaveis, c => c.BindNonPublicProperties = true);

            services.AddSingleton(jwtVariaveis);

            var conexaoDadosVariaveis = new ConnectionStringOptions();
            Configuration.GetSection("ConnectionStrings").Bind(conexaoDadosVariaveis, c => c.BindNonPublicProperties = true);

            services.AddSingleton(conexaoDadosVariaveis);

            var sentryOptions = new SentryOptions();            
            Configuration.GetSection("Sentry").Bind(sentryOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(sentryOptions);

            RegistraDependencias.Registrar(services);
            RegistraAutenticacao.Registrar(services, jwtVariaveis);
            RegistrarMvc.Registrar(services, sentryOptions);

            services.AddResponseCompression();
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SME.SERAp.Prova.Api v1"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseMetricServer();

            app.UseHttpMetrics();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
