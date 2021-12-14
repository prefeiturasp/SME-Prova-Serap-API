using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterContextosProvasPorProvaIdUseCase
    {
        Task<IEnumerable<ContextoProvaDto>> Executar(long id);
    }
}
