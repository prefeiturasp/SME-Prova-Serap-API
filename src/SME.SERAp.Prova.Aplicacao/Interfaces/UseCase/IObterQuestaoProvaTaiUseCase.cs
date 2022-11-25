using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterQuestaoProvaTaiUseCase
    {
        Task<bool> Executar(long provaId);
    }
}
