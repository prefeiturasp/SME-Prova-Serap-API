using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestaoAlunoResposta : IRepositorioBase<QuestaoAlunoResposta>
    {
        Task<QuestaoAlunoResposta> ObterPorIdRaAsync(long questaoId, long alunoRa);
        Task<IEnumerable<QuestaoAlunoResposta>> ObterPorProvaIdERaAsync(long provaId, long alunoRa);
    }
}
