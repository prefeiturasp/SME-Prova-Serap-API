using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterVersaoApiUseCase
    {
        public Task<string> Executar();
    }
}
