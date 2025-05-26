using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoAlternativaComCriadoEmTaiQuery : IRequest<IEnumerable<QuestaoAlunoRespostaCriadoEmDto>>
    {
        public ObterQuestaoAlternativaComCriadoEmTaiQuery(long provaId, long alunoRa)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
        }

        public long ProvaId { get; }
        public long AlunoRa { get; }
    }
}
