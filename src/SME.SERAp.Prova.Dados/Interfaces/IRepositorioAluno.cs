using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAluno
    {
        Task<ObterAlunoAtivoRetornoDto> ObterAlunoAtivoAsync(long alunoRA);
    }
}
