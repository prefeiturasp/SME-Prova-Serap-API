using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Interfaces.UseCase
{
    public interface IDeletarProvaPresencaUseCase
    {
        Task<bool> Executar(long id);
    }
}