using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaDetalhesResumidoCadernoUseCase
    {
        Task<ProvaDetalheResumidoCadernoRetornoDto> Executar(long provaId, string caderno);
    }
}
