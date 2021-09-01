using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAlternativa : IRepositorioBase<Alternativa>
    {
        Task<bool> RemoverPorProvaId(long provaId);
    }
}
