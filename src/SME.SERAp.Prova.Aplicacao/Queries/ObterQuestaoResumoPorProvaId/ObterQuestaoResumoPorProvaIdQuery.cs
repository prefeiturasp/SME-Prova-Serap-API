using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoResumoPorProvaIdQuery : IRequest<IEnumerable<QuestaoResumoProvaDto>>
    {
        public ObterQuestaoResumoPorProvaIdQuery(long provaId, long alunoId)
        {
            ProvaId = provaId;
            AlunoId = alunoId;
        }

        public long ProvaId { get; set; }
        public long AlunoId { get; set; }
    }
}
