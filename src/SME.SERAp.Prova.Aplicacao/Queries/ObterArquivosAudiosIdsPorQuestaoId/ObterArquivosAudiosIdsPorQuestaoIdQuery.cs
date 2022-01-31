using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivosAudiosIdsPorQuestaoIdQuery : IRequest<long[]>
    {

        public ObterArquivosAudiosIdsPorQuestaoIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }

        public long QuestaoId { get; set; }
    }
}
