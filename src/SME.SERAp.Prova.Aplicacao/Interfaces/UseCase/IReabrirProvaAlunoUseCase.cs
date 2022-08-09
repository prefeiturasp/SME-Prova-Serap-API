using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IReabrirProvaAlunoUseCase
    {
        Task<bool> Executar(long provaId, long[] alunosRA);
    }
}
