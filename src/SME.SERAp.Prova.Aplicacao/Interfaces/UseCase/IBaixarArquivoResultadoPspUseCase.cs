using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IBaixarArquivoResultadoPspUseCase
    {
        Task<(byte[], string)> Executar(long processoId);
    }
}
