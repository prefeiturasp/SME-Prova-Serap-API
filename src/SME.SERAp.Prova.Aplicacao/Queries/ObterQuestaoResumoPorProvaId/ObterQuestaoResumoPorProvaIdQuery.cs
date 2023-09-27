using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoResumoPorProvaIdQuery : IRequest<IEnumerable<QuestaoResumoProvaDto>>
    {
        public ObterQuestaoResumoPorProvaIdQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
