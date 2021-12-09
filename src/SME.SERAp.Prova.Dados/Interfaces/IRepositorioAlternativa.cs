using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAlternativa : IRepositorioBase<Alternativa>
    {
        Task<bool> RemoverPorProvaId(long provaId);
        Task<IEnumerable<Alternativa>> ObterTodosParaCacheAsync();
    }
}
