using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestaoAlunoResposta : IRepositorioBase<QuestaoAlunoResposta>
    {
        Task<QuestaoAlunoResposta> ObterPorIdRaAsync(long questaoId, long alunoRa);
    }
}
