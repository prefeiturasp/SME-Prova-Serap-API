using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaCadernosAreaAdministrativoUseCase {
        Task<ProvaCadernoRetornoDto> Executar(long provaId);
    }
}
