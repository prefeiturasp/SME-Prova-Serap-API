using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarQuestaoAlunoRespostaCommand : IRequest<bool>
    {
        public AtualizarQuestaoAlunoRespostaCommand(QuestaoAlunoResposta questaoAlunoResposta)
        {
            QuestaoAlunoResposta = questaoAlunoResposta;
        }

        public QuestaoAlunoResposta QuestaoAlunoResposta { get; set; }
    }
}
