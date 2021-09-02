using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterArquivoPorIdLegadoUseCase
    {
        Task<ArquivoRetornoDto> Executar(long id);
    }
}
