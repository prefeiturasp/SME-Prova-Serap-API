using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaResultadoResumoUseCase
    {
        Task<ProvaResultadoResumoDto> Executar(long provaId, int caderno);
    }
}
