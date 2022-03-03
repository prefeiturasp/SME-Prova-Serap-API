using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IPotenciacaoRUseCase
    {
        Task<string> Executar(int _base, int _expoente);
    }
}
