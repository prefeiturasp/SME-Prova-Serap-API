using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterQuestoesCompletaPorLegadoIdsUseCase
    {
        Task<string> Executar(long[] legadoIds);
    }
}
