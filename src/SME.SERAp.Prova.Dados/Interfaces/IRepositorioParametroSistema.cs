using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioParametroSistema : IRepositorioBase<ParametroSistema>
    {
        Task<ParametroSistema> ObterPorTipoEAno(int tipo, int ano);
    }
}
