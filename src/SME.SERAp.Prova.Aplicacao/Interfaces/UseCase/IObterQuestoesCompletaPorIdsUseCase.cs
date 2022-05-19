using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterQuestoesCompletaPorIdsUseCase
    {
        Task<IEnumerable<QuestaoCompletaDto>> Executar(long[] ids);
    }
}
