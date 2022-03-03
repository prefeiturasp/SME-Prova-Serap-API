using System.Collections.Generic;
using System.Threading.Tasks;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestao : IRepositorioBase<Questao>
    {
        Task<Questao> ObterPorIdLegadoAsync(long id);
        Task<bool> RemoverPorProvaIdAsync(long provaId);
        Task<IEnumerable<Questao>> ObterTodasParaCacheAsync();
        Task<Questao> ObterPorArquivoAudioIdAsync(long arquivoAudioId);
        Task<IEnumerable<Questao>> ObterQuestoesPorProvaIdAsync(long provaId);
    }
}
