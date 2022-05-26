using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioContextoProva : IRepositorioBase<ContextoProva>
    {
        Task<IEnumerable<ContextoProva>> ObterContextoProvaPorProvaId(long provaId);
        Task<IEnumerable<ContextoResumoProvaDto>> ObterContextoProvaResumoPorProvaIdAsync(long provaId);
    }
}
