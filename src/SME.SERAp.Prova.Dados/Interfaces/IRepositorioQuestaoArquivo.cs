using System.Threading.Tasks;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestaoArquivo : IRepositorioBase<QuestaoArquivo>
    {
        Task<QuestaoArquivo> ObterPorArquivoIdAsync(long id);
    }
}
