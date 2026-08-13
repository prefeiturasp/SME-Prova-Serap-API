using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Interfaces.UseCase
{
    public interface ICriarProvaPresencaUseCase
    {
        Task<bool> Executar(CriarProvaPresencaDto provaPresencaDto);
    }
}