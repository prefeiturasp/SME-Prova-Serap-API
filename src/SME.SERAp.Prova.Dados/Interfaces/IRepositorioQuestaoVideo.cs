using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestaoVideo : IRepositorioBase<QuestaoVideo>
    {
        Task<IEnumerable<QuestaoVideo>> ObterPorQuestaoId(long questaoId);
        Task<IEnumerable<QuestaoVideo>> ObterPorProvaId(long provaId);
        Task<QuestaoVideo> ObterPorArquivoId(long arquivoId);
    }
}
