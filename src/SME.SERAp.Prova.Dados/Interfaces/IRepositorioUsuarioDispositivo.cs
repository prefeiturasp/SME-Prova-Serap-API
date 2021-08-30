using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Interfaces
{
    public interface IRepositorioUsuarioDispositivo : IRepositorioBase<UsuarioDispositivo>
    {
        Task<IEnumerable<UsuarioDispositivo>> ObterPorDispositivoRaAsync(string dispositivoId, long ra);
        Task<bool> RemoverPorIds(long[] ids);
    }
}
