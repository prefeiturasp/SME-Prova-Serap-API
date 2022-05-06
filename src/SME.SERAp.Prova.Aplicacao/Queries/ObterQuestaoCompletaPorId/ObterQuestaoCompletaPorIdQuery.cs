using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaPorIdQuery : IRequest<QuestaoCompletaDto>
    {
        public ObterQuestaoCompletaPorIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }

        public long QuestaoId { get; set; }
    }
}
