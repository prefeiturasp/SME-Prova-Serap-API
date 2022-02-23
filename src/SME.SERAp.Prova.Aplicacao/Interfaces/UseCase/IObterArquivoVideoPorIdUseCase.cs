using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterArquivoVideoPorIdUseCase
    {
        Task<ArquivoVideoResponseDto> Executar(long id);
    }
}
