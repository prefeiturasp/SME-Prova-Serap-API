using SME.SERAp.Prova.Infra.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaResumoAreaAdministrativoUseCase
    {
        Task<IEnumerable<ProvaResumoAdministrativoRetornoDto>> Executar(long provaId, string caderno = null);
    }
}
