using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioArquivo : IRepositorioBase<Arquivo>
    {
        Task<bool> RemoverPorIdsAsync(long[] idsArquivos);
        Task<Arquivo> ObterPorIdLegadoAsync(long id);
        Task<IEnumerable<Arquivo>> ObterArquivosAudioPorQuestaoIdAsync(long questaoId);
    }
}
