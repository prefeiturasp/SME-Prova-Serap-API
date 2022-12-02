using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAlunoProvaProficiencia : IRepositorioBase<AlunoProvaProficiencia>
    {
        Task<decimal> ObterProficienciaFinalAlunoPorProvaIdAsync(long provaId, long alunoId);
    }
}
