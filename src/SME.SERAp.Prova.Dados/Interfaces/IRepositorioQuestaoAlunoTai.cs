using System.Collections.Generic;
using System.Threading.Tasks;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos.Questao;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestaoAlunoTai : IRepositorioBase<QuestaoAlunoTai>
    {
        Task<IEnumerable<QuestaoTaiDto>> ObterQuestoesTaiPorProvaAlunoAsync(long provaId, long alunoId);
    }
}