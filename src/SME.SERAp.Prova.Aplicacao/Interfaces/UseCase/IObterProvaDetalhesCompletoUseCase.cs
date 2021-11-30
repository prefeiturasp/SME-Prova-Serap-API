using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaDetalhesCompletoUseCase
    {
        Task<ProvaDetalheCompletoRetornoDto> Executar(long provaId);
    }
}
