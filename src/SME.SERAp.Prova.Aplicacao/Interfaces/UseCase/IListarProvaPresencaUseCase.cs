using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Interfaces.UseCase
{
    public interface IListarProvaPresencaUseCase
    {
        Task<IEnumerable<ListarProvaPresencaDto>> Executar();
    }
}