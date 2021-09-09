using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExcluirQuestaoAlunoRespostaPorIdCommand : IRequest<bool>
    {
        public ExcluirQuestaoAlunoRespostaPorIdCommand(QuestaoAlunoResposta questaoAlunoResposta)
        {
            QuestaoAlunoResposta = questaoAlunoResposta;
        }

        public QuestaoAlunoResposta  QuestaoAlunoResposta { get; set; }
    }
}
