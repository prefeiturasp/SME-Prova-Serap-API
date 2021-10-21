using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        Task<long> SalvarAsync(T entidade);
        Task<T> ObterPorIdAsync(long id);
        Task<long> IncluirAsync(T entidade);
        Task<long> UpdateAsync(T entidade);
        Task<bool> RemoverFisicamenteAsync(T entidade);
    }
}
