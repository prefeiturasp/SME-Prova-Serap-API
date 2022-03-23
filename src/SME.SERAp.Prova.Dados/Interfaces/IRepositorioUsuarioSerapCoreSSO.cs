using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioUsuarioSerapCoreSSO
    {
        Task<UsuarioSerapCoreSSO> ObterPorLogin(string login);
    }
}
