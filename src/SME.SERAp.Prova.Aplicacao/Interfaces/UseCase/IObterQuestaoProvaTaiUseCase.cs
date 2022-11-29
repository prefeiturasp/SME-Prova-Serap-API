using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterQuestaoProvaTaiUseCase
    {
        Task<string> Executar(long provaId);
    }
}
