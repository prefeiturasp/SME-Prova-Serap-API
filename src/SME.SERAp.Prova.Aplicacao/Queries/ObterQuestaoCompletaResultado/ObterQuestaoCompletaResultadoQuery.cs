using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaResultadoQuery : IRequest<QuestaoCompletaResultadoDto>
    {
        public ObterQuestaoCompletaResultadoQuery(long alunoRa, long provaId, long questaoLegadoId)
        {
            AlunoRa = alunoRa;
            ProvaId = provaId;
            QuestaoLegadoId = questaoLegadoId;
        }

        public long AlunoRa { get; set; }
        public long ProvaId { get; set; }
        public long QuestaoLegadoId { get; set; }

    }
}
