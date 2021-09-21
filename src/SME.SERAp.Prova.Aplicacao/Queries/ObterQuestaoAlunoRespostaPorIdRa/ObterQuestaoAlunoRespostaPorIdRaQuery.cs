using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoAlunoRespostaPorIdRaQuery : IRequest<QuestaoAlunoResposta>
    {
        public ObterQuestaoAlunoRespostaPorIdRaQuery(long questaoId, long alunoRa)
        {
            QuestaoId = questaoId;
            AlunoRa = alunoRa;
        }

        public long QuestaoId { get; set; }
        public long AlunoRa { get; set; }
    }
}
