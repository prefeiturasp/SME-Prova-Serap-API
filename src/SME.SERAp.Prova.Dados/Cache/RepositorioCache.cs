using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra.Interfaces;
using SME.SERAp.Prova.Infra.Utils;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Cache
{
    public class RepositorioCache : IRepositorioCache
    {

        private readonly IServicoLog servicoLog;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;

        public RepositorioCache(IServicoLog servicoLog, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {

            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            this.distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public string Obter(string nomeChave, bool utilizarGZip = false)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var cacheParaRetorno = memoryCache.Get<string>("nomeChave");
                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Obtendo", inicioOperacao, timer.Elapsed, true);

                if (utilizarGZip)
                {
                    cacheParaRetorno = UtilGZip.Descomprimir(Convert.FromBase64String(cacheParaRetorno));
                }

                return cacheParaRetorno;
            }
            catch (Exception ex)
            {
                //Caso o cache esteja indisponível a aplicação precisa continuar funcionando mesmo sem o cache
                servicoLog.Registrar(ex);
                timer.Stop();

                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, $"Obtendo - Erro {ex.Message}", inicioOperacao, timer.Elapsed, false);
                return null;
            }
        }

        public async Task<T> ObterAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720, bool utilizarGZip = false)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var stringCache = memoryCache.Get<string>(nomeChave);

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Obtendo", inicioOperacao, timer.Elapsed, true);

                if (!string.IsNullOrWhiteSpace(stringCache))
                {
                    if (utilizarGZip)
                    {
                        stringCache = UtilGZip.Descomprimir(Convert.FromBase64String(stringCache));
                    }                    
                    return JsonSerializer.Deserialize<T>(stringCache);
                }
                
                var dados = await buscarDados();

                await SalvarAsync(nomeChave, JsonSerializer.Serialize(dados), minutosParaExpirar, utilizarGZip);

                return dados;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
                timer.Stop();

                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, $"Obtendo - Erro {ex.Message}", inicioOperacao, timer.Elapsed, false);
                return default;
            }
        }

        public async Task<string> ObterAsync(string nomeChave, bool utilizarGZip = false)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var stringCache = memoryCache.Get<string>(nomeChave);

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Obtendo", inicioOperacao, timer.Elapsed, true);


                if (!string.IsNullOrWhiteSpace(stringCache) && utilizarGZip)
                {
                    stringCache = UtilGZip.Descomprimir(Convert.FromBase64String(stringCache));
                }

                return await Task.FromResult(stringCache);

            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
                timer.Stop();

                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, $"Obtendo - Erro {ex.Message}", inicioOperacao, timer.Elapsed, false);
                return default;
            }
        }

        public async Task RemoverAsync(string nomeChave)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                await Task.Run(() => memoryCache.Remove(nomeChave));

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Remover async", inicioOperacao, timer.Elapsed, true);
            }
            catch (Exception ex)
            {
                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Remover async", inicioOperacao, timer.Elapsed, false);
                servicoLog.Registrar(ex);
            }
        }

        public void Salvar(string nomeChave, string valor, int minutosParaExpirar = 720, bool utilizarGZip = false)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {

                if (utilizarGZip)
                {
                    var valorComprimido = UtilGZip.Comprimir(valor);
                    valor = Convert.ToBase64String(valorComprimido);
                }

                memoryCache.Set(nomeChave, valor, TimeSpan.FromMinutes(minutosParaExpirar));

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Salvar async", inicioOperacao, timer.Elapsed, true);

            }
            catch (Exception ex)
            {
                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Salvar", inicioOperacao, timer.Elapsed, false);
                servicoLog.Registrar(ex);
            }
        }

        public async Task SalvarAsync(string nomeChave, string valor, int minutosParaExpirar = 720, bool utilizarGZip = false)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                if (!string.IsNullOrWhiteSpace(valor) && valor != "[]")
                {

                    if (utilizarGZip)
                    {
                        var valorComprimido = UtilGZip.Comprimir(valor);
                        valor = Convert.ToBase64String(valorComprimido);
                    }

                    await Task.Run(() => memoryCache.Set(nomeChave, valor, TimeSpan.FromMinutes(minutosParaExpirar)));

                    timer.Stop();
                    servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Salvar async", inicioOperacao, timer.Elapsed, true);

                }
            }
            catch (Exception ex)
            {
                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("MemoryCache", nomeChave, "Salvar", inicioOperacao, timer.Elapsed, false);
                servicoLog.Registrar(ex);
            }
        }

        public async Task SalvarAsync(string nomeChave, object valor, int minutosParaExpirar = 720, bool utilizarGZip = false)
        {
            await SalvarAsync(nomeChave, JsonSerializer.Serialize(valor), minutosParaExpirar, utilizarGZip);
        }

        public async Task SalvarRedisAsync(string nomeChave, object valor, int minutosParaExpirar = 720)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();
            {
                await distributedCache.SetStringAsync(nomeChave, JsonSerializer.Serialize(valor), new DistributedCacheEntryOptions()
                                                .SetAbsoluteExpiration(TimeSpan.FromMinutes(minutosParaExpirar)));

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("Redis", nomeChave, "Salvar Redis Async", inicioOperacao, timer.Elapsed, true);
            }
            
        }

        public async Task<T> ObterRedisAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720)
        {
            var inicioOperacao = DateTime.UtcNow;
            var timer = System.Diagnostics.Stopwatch.StartNew();

            try
            {

                var stringCache = await distributedCache.GetStringAsync(nomeChave);

                timer.Stop();
                servicoLog.RegistrarDependenciaAppInsights("Redis", nomeChave, "Obtendo", inicioOperacao, timer.Elapsed, true);


                if (!string.IsNullOrWhiteSpace(stringCache))
                {
                    return JsonSerializer.Deserialize<T>(stringCache);
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
                return default;
            }
        }

    }
}
