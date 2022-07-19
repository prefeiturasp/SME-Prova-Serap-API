using MediatR;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaPorLegadoIdQuery : IRequest<IEnumerable<string>>
    {
        public ObterQuestaoCompletaPorLegadoIdQuery(long[] legadoIds)
        {
            LegadoIds = legadoIds;
        }

        public long[] LegadoIds { get; set; }
    }
}
