using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Interfaces.UseCase
{
    public interface IObterProvaPresencaPorIdUseCase
    {
        Task<ListarProvaPresencaDto> Executar(long id);
    }
}