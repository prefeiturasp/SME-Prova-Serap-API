using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlternativaAlunoRespostaQuery : IRequest<IEnumerable<QuestaoAlternativaAlunoRespostaDto>>
    {
        public ObterAlternativaAlunoRespostaQuery(long provaId, long alunoRa)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
    }
}
