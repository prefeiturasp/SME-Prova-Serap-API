using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IIncluirProvaAlunoUseCase
    {
        Task<bool> Executar(long provaId, int status);
    }
}
