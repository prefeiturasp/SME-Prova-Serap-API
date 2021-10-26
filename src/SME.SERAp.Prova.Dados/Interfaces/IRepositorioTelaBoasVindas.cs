using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioTelaBoasVindas : IRepositorioBase<Dominio.TelaBoasVindas>
    {
        Task<IEnumerable<TelaBoasVindas>> ObterAtivosAsync();
    }
}
