using MediatR;
using SME.SERAp.Prova.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarQuestaoAlunoRespostaCommandHandler : IRequestHandler<AtualizarQuestaoAlunoRespostaCommand, bool>
    {
        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public AtualizarQuestaoAlunoRespostaCommandHandler(IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoAlunoResposta));
        }
        public async Task<bool> Handle(AtualizarQuestaoAlunoRespostaCommand request, CancellationToken cancellationToken) =>
            await repositorioQuestaoAlunoResposta.UpdateAsync(request.QuestaoAlunoResposta) > 0;
    }
}
