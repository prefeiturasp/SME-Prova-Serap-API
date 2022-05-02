using Elastic.Apm.AspNetCore;
using Elastic.Apm.DiagnosticSource;
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
using Sentry;
using SME.SERAp.Prova.Api.Configuracoes;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.IoC;
using StackExchange.Redis;
using System.IO.Compression;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var jwtVariaveis = new JwtOptions();
            Configuration.GetSection(nameof(JwtOptions)).Bind(jwtVariaveis, c => c.BindNonPublicProperties = true);
            services.AddSingleton(jwtVariaveis);

            var conexaoDadosVariaveis = new ConnectionStringOptions();
            Configuration.GetSection("ConnectionStrings").Bind(conexaoDadosVariaveis, c => c.BindNonPublicProperties = true);
            services.AddSingleton(conexaoDadosVariaveis);

            var sentryOptions = new SentryOptions();
            Configuration.GetSection("Sentry").Bind(sentryOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(sentryOptions);

            var gitHubOptions = new GithubOptions();
            Configuration.GetSection("Github").Bind(gitHubOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(gitHubOptions);

            var logOptions = new LogOptions();
            Configuration.GetSection("Logs").Bind(logOptions, c => c.BindNonPublicProperties = true);
            logOptions.SentryDSN = sentryOptions.Dsn;
            services.AddSingleton(logOptions);

            var telemetriaOptions = new TelemetriaOptions();
            Configuration.GetSection(TelemetriaOptions.Secao).Bind(telemetriaOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(telemetriaOptions);

            var rabbitOptions = new RabbitOptions();
            Configuration.GetSection("Rabbit").Bind(rabbitOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(rabbitOptions);

            var factory = new ConnectionFactory
            {
                HostName = rabbitOptions.HostName,
                UserName = rabbitOptions.UserName,
                Password = rabbitOptions.Password,
                VirtualHost = rabbitOptions.VirtualHost
            };

            var conexaoRabbit = factory.CreateConnection();

            services.AddSingleton(conexaoRabbit);

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
            if(threadPoolOptions.WorkerThreads > 0 && threadPoolOptions.CompletionPortThreads > 0)
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
            RegistraMvc.Registrar(services, sentryOptions);
            RegistraDocumentacaoSwagger.Registrar(services);

            var serviceProvider = services.BuildServiceProvider();
            var clientTelemetry = serviceProvider.GetService<TelemetryClient>();
            var servicoTelemetria = new ServicoTelemetria(clientTelemetry, telemetriaOptions);
            services.AddSingleton(servicoTelemetria);

            DapperExtensionMethods.Init(servicoTelemetria);

            IniciarPropagacaoCache(services);
        }

        private static void IniciarPropagacaoCache(IServiceCollection services)
        {
            services.AddStartupTask<WarmUpCacheTask>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseElasticApm(Configuration,
               new SqlClientDiagnosticSubscriber(),
               new HttpDiagnosticsSubscriber());

            var muxer = app.ApplicationServices.GetService<IConnectionMultiplexer>();
            muxer.UseElasticApm();

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
