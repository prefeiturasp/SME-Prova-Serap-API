using Elastic.Apm.AspNetCore;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.NetCoreAll;
using Elastic.Apm.SqlClient;
using Elastic.Apm.StackExchange.Redis;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;
using RabbitMQ.Client;
using SME.SERAp.Prova.Api.Configuracoes;
using SME.SERAp.Prova.Api.Converters;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.IoC;
using StackExchange.Redis;
using System;
using System.Threading;

namespace SME.SERAp.Prova.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });

            var pathOptions = new PathOptions();
            Configuration.GetSection("Path").Bind(pathOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(pathOptions);

            var jwtVariaveis = new JwtOptions();
            Configuration.GetSection(nameof(JwtOptions)).Bind(jwtVariaveis, c => c.BindNonPublicProperties = true);
            services.AddSingleton(jwtVariaveis);

            var conexaoDadosVariaveis = new ConnectionStringOptions();
            Configuration.GetSection("ConnectionStrings").Bind(conexaoDadosVariaveis, c => c.BindNonPublicProperties = true);
            services.AddSingleton(conexaoDadosVariaveis);

            var apiROptions = new ApiROptions();
            Configuration.GetSection(ApiROptions.Secao).Bind(apiROptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(apiROptions);

            var gitHubOptions = new GithubOptions();
            Configuration.GetSection("Github").Bind(gitHubOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(gitHubOptions);

            var telemetriaOptions = new TelemetriaOptions();
            Configuration.GetSection(TelemetriaOptions.Secao).Bind(telemetriaOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(telemetriaOptions);

            if (telemetriaOptions.Apm == true)
            {
                services.AddElasticApm(new HttpDiagnosticsSubscriber());
            }

            var rabbitOptions = new RabbitOptions();
            Configuration.GetSection("Rabbit").Bind(rabbitOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(rabbitOptions);

            services.AddSingleton<IConnectionFactory>(new ConnectionFactory
            {
                HostName = rabbitOptions.HostName,
                UserName = rabbitOptions.UserName,
                Password = rabbitOptions.Password,
                VirtualHost = rabbitOptions.VirtualHost,
                AutomaticRecoveryEnabled = true
            });

            services.AddSingleton<IConnection>(sp =>
            {
                var factory = sp.GetRequiredService<IConnectionFactory>();
                return factory.CreateConnectionAsync().GetAwaiter().GetResult();
            });

            var configuracaoRabbitLogOptions = new RabbitLogOptions();
            Configuration.GetSection("RabbitLog").Bind(configuracaoRabbitLogOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(configuracaoRabbitLogOptions);

            services.Configure<CryptographyOptions>(Configuration.GetSection("Cryptography"));

            services.AddHttpContextAccessor();
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            var threadPoolOptions = new ThreadPoolOptions();
            Configuration.GetSection("ThreadPoolOptions").Bind(threadPoolOptions, c => c.BindNonPublicProperties = true);
            if (threadPoolOptions.WorkerThreads > 0 && threadPoolOptions.CompletionPortThreads > 0)
                ThreadPool.SetMinThreads(threadPoolOptions.WorkerThreads, threadPoolOptions.CompletionPortThreads);

            var redisOptions = new RedisOptions();
            Configuration.GetSection("RedisOptions").Bind(redisOptions, c => c.BindNonPublicProperties = true);
            var redisConfigurationOptions = new ConfigurationOptions()
            {
                Proxy = redisOptions.Proxy,
                SyncTimeout = redisOptions.SyncTimeout,
                EndPoints = { redisOptions.Endpoint }
            };

            var muxer = ConnectionMultiplexer.Connect(redisConfigurationOptions);
            services.AddSingleton<IConnectionMultiplexer>(muxer);

            RegistraClientesHttp.Registrar(services, gitHubOptions);

            RegistraDependencias.Registrar(services);

            RegistraAutenticacao.Registrar(services, jwtVariaveis);

            RegistraDocumentacaoSwagger.Registrar(services);

            services.AddSingleton(sp =>
            {
                var clientTelemetry = sp.GetService<TelemetryClient>();
                var telemetriaOptionsService = sp.GetRequiredService<TelemetriaOptions>();
                return new ServicoTelemetria(clientTelemetry, telemetriaOptionsService);
            });

            var serviceProviderFinal = services.BuildServiceProvider();
            var servicoTelemetriaParaDapper = serviceProviderFinal.GetRequiredService<ServicoTelemetria>();
            DapperExtensionMethods.Init(servicoTelemetriaParaDapper);
            RegistraMvc.Registrar(services, serviceProviderFinal);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI();

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