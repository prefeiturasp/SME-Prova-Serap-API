using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAlunoEol
    {
        Task<ObterAlunoAtivoEolRetornoDto> ObterAlunoAtivoAsync(long alunoRA);
    }
}
