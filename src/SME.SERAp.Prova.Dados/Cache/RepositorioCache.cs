using MessagePack;
using SME.SERAp.Prova.Infra.Interfaces;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Cache
{
    public class RepositorioCache : IRepositorioCache
    {
        private readonly IServicoLog servicoLog;
        private readonly IDatabase database;

        public RepositorioCache(IServicoLog servicoLog, IConnectionMultiplexer connectionMultiplexer)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
            if (connectionMultiplexer == null) throw new ArgumentNullException(nameof(connectionMultiplexer));
            this.database = connectionMultiplexer.GetDatabase();
        }

        public async Task SalvarRedisAsync(object valor, string cacheChave, params object[] chaves)
        {
            var nomeChave = string.Format(cacheChave, chaves);
            await SalvarRedisAsync(nomeChave, valor);
        }

        public async Task SalvarRedisAsync(string nomeChave, object valor, int minutosParaExpirar = 720)
        {
            try
            {
                if (valor != null)
                {
                    await database.StringSetAsync(nomeChave, MessagePackSerializer.Serialize(valor), TimeSpan.FromMinutes(minutosParaExpirar));
                }
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
            }
        }

        public async Task RemoverRedisAsync(string nomeChave)
        {
            try
            {
                await database.KeyDeleteAsync(nomeChave);
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
            }
        }

        public async Task<T> ObterRedisAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720)
        {
            try
            {
                byte[] byteCache = await database.StringGetAsync(nomeChave);

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
                return await buscarDados();
            }
        }

        public async Task<T> ObterRedisAsync<T>(string nomeChave)
        {
            try
            {
                byte[] byteCache = await database.StringGetAsync(nomeChave);

                if (byteCache != null)
                {
                    return MessagePackSerializer.Deserialize<T>(byteCache);
                }
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
            }

            return default;
        }

        public async Task<bool> ExisteChaveAsync(string nomeChave)
        {
            try
            {
                return await database.KeyExistsAsync(nomeChave);
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
            }

            return false;
        }
    }
}
