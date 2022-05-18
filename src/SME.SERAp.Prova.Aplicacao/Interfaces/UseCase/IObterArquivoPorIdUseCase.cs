using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterArquivoPorIdUseCase
    {
        Task<ArquivoRetornoDto> Executar(long id);
    }
}

