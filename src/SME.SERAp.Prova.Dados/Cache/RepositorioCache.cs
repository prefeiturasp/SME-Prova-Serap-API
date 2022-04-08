using MessagePack;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using SME.SERAp.Prova.Infra.Interfaces;
using SME.SERAp.Prova.Infra.Utils;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Cache
{
    public class RepositorioCache : IRepositorioCache
    {

        private readonly IServicoLog servicoLog;
        private readonly IConnectionMultiplexer distributedCache;

        public RepositorioCache(IServicoLog servicoLog, IConnectionMultiplexer distributedCache)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
            this.distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public async Task SalvarRedisAsync(string nomeChave, object valor, int minutosParaExpirar = 720)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            var db = distributedCache.GetDatabase();
            await db.StringSetAsync(nomeChave, MessagePackSerializer.Serialize(valor), TimeSpan.FromMinutes(minutosParaExpirar));

            timer.Stop();
            servicoLog.RegistrarDependenciaAppInsights("Redis", nomeChave, "Salvar Redis Async", inicioOperacao, timer.Elapsed, true);
        }

        public async Task RemoverRedisAsync(string nomeChave)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var db = distributedCache.GetDatabase();
                await db.KeyDeleteAsync(nomeChave);
                timer.Stop();
            }
            catch (Exception ex)
            {
                timer.Stop();
                servicoLog.Registrar(ex);
            }
        }

        public async Task<T> ObterRedisAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var db = distributedCache.GetDatabase();
                byte[] byteCache = await db.StringGetAsync(nomeChave);

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("Redis", nomeChave, "Obtendo", inicioOperacao, timer.Elapsed, true);

                if (byteCache != null)
                {
                    return MessagePackSerializer.Deserialize<T>(byteCache);
                }

                var dados = await buscarDados();
                await SalvarRedisAsync(nomeChave, dados, minutosParaExpirar);

                return dados;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
                timer.Stop();

                servicoLog.RegistrarDependenciaAppInsights("Redis", nomeChave, $"Obtendo - Erro {ex.Message}", inicioOperacao, timer.Elapsed, false);
            }

            return default;
        }

        public async Task<T> ObterRedisAsync<T>(string nomeChave)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var db = distributedCache.GetDatabase();
                byte[] byteCache = await db.StringGetAsync(nomeChave);

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("Redis", nomeChave, "Obtendo", inicioOperacao, timer.Elapsed, true);

                if (byteCache != null)
                {
                    return MessagePackSerializer.Deserialize<T>(byteCache);
                }
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
                timer.Stop();

                servicoLog.RegistrarDependenciaAppInsights("Redis", nomeChave, $"Obtendo - Erro {ex.Message}", inicioOperacao, timer.Elapsed, false);
            }

            return default;
        }
    }
}
