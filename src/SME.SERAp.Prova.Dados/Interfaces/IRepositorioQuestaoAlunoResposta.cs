using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestaoAlunoResposta : IRepositorioBase<QuestaoAlunoResposta>
    {
        Task<QuestaoAlunoResposta> ObterPorIdRaAsync(long questaoId, long alunoRa);
        Task<IEnumerable<QuestaoAlunoResposta>> ObterPorProvaIdERaAsync(long provaId, long alunoRa);
        Task<QuestaoCompletaResultadoDto> ObterResultadoQuestaoAsync(long alunoRa, long provaId, long questaoLegadoId);
        Task<IEnumerable<QuestaoAlternativaAlunoRespostaDto>> QuestaoAlternativaAlunoRespostaTaiAsync(long alunoRa, long provaId);
        Task<IEnumerable<QuestaoAlunoRespostaCriadoEmDto>> ObterQuestaoAlternativaComCriadoEmTaiAsync(long alunoRa, long provaId);

    }
}
