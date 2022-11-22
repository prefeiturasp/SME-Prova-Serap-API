using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IIniciarProvaTaiUseCase
    {
        public Task<bool> Executar(long provaId);
    }
}
