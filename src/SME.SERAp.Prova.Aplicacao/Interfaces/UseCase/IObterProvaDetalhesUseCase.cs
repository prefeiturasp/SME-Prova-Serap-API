using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaDetalhesUseCase
    {
        Task<ProvaDetalheResumidoRetornoDto> Executar(long provaId);
    }
}
