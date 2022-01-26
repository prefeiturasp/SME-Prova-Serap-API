using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterArquivoAudioPorIdUseCase
    {
        Task<ArquivoRetornoDto> Executar(long id);
    }
}
