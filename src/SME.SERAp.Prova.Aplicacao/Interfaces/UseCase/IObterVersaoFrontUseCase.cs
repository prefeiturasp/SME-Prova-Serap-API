using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterVersaoFrontUseCase
    {
        public Task<string> Executar();
    }
}
