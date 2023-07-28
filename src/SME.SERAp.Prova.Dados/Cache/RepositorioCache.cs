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

            database = connectionMultiplexer.GetDatabase();
        }

        public async Task SalvarRedisAsync(string nomeChave, object valor, int minutosParaExpirar = 720)
        {
            try
            {
                if (valor != null)
                    await database.StringSetAsync(nomeChave, MessagePackSerializer.Serialize(valor), TimeSpan.FromMinutes(minutosParaExpirar));
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
                    return MessagePackSerializer.Deserialize<T>(byteCache);

                var dados = await buscarDados();

                if(dados != null)
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
        public async Task SalvarRedisToJsonAsync(string nomeChave, string json, int minutosParaExpirar = 720)
        {
            try
            {
                if (!string.IsNullOrEmpty(json))
                {
                    var bytes = MessagePackSerializer.ConvertFromJson(json);                    
                    await database.StringSetAsync(nomeChave, bytes, TimeSpan.FromMinutes(minutosParaExpirar));
                }
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
            }
        }

        public async Task<string> ObterRedisToJsonAsync(string nomeChave, Func<Task<string>> buscarDados, int minutosParaExpirar = 720)
        {
            try
            {
                byte[] byteCache = await database.StringGetAsync(nomeChave);

                if (byteCache != null)
                    return MessagePackSerializer.ConvertToJson(byteCache);

                var dados = await buscarDados();
                await SalvarRedisToJsonAsync(nomeChave, dados, minutosParaExpirar);

                return dados;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
                return await buscarDados();
            }
        }

        public async Task<string> ObterRedisToJsonAsync(string nomeChave)
        {
            try
            {
                byte[] byteCache = await database.StringGetAsync(nomeChave);

                if (byteCache != null)
                    return MessagePackSerializer.ConvertToJson(byteCache);
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(ex);
            }

            return default;
        }
    }
}
