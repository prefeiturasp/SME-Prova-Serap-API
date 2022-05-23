using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaPorIdQuery : IRequest<IEnumerable<string>>
    {
        public ObterQuestaoCompletaPorIdQuery(long[] questoesIds)
        {
            QuestoesIds = questoesIds;
        }

        public long[] QuestoesIds { get; set; }
    }
}
