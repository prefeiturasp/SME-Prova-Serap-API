using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaDetalhesResumidoUseCase
    {
        Task<ProvaDetalheResumidoRetornoDto> Executar(long provaId);
    }
}
