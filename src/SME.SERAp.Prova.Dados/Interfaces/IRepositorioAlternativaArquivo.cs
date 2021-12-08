using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAlternativaArquivo : IRepositorioBase<AlternativaArquivo>
    {
        Task<bool> RemoverPorIdsAsync(long[] ids);
        Task<IEnumerable<AlternativaArquivo>> ObterArquivosPorProvaIdAsync(long id);
        Task<AlternativaArquivo> ObterPorArquivoIdAsync(long id);
    }
}
