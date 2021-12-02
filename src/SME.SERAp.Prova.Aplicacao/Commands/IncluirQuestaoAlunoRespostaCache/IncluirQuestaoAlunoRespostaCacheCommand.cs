using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirQuestaoAlunoRespostaCacheCommand : IRequest<bool>
    {
        public IncluirQuestaoAlunoRespostaCacheCommand(QuestaoAlunoRespostaSincronizarDto dto)
        {
            Dto = dto;
        }
        public QuestaoAlunoRespostaSincronizarDto Dto { get; set; }
    }
}
