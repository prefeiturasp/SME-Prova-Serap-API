using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioPreferenciasUsuario : IRepositorioBase<PreferenciasUsuario>
    {
        Task<PreferenciasUsuario> ObterPorUsuarioId(long usuarioId);
        Task<PreferenciasUsuario> ObterPorLogin(long login);
    }
}