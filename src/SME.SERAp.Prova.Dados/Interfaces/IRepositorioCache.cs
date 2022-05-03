using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioCache
    {
        Task SalvarRedisAsync(string nomeChave, object valor, int minutosParaExpirar = 720);
        Task RemoverRedisAsync(string nomeChave);
        Task<T> ObterRedisAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720);
        Task<T> ObterRedisAsync<T>(string nomeChave);
    }
}
