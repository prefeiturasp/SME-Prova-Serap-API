using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface ITratarImportacaoResultadoPspUseCase
    {
        Task<bool> Executar(long processoId, int tipoResultado);
    }
}
