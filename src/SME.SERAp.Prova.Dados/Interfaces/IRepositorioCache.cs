using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioCache
    {
        // string Obter(string nomeChave, bool utilizarGZip = false);
        //
        // Task<string> ObterAsync(string nomeChave, bool utilizarGZip = false);
        //
        // Task<T> ObterAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720, bool utilizarGZip = false);
        //
        // Task RemoverAsync(string nomeChave);
        //
        // void Salvar(string nomeChave, string valor, int minutosParaExpirar = 720, bool utilizarGZip = false);
        //
        // Task SalvarAsync(string nomeChave, string valor, int minutosParaExpirar = 720, bool utilizarGZip = false);
        //
        // Task SalvarAsync(string nomeChave, object valor, int minutosParaExpirar = 720, bool utilizarGZip = false);
        //
        Task SalvarRedisAsync(string nomeChave, object valor, int minutosParaExpirar = 720);

        Task RemoverRedisAsync(string nomeChave);

        Task<T> ObterRedisAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720);

        Task<T> ObterRedisAsync<T>(string nomeChave);
    }
}
