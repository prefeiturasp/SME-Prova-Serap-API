using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorQuestaoIdRaQuery : IRequest<ProvaAluno>
    {
        public ObterProvaAlunoPorQuestaoIdRaQuery(long questaoId, long alunoRa)
        {
            QuestaoId = questaoId;
            AlunoRa = alunoRa;
        }

        public long QuestaoId { get; set; }
        public long AlunoRa { get; set; }
    }
}
