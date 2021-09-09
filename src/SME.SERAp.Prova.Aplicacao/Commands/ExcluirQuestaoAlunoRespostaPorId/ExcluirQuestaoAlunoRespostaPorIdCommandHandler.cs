using MediatR;
using SME.SERAp.Prova.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExcluirQuestaoAlunoRespostaPorIdCommandHandler : IRequestHandler<ExcluirQuestaoAlunoRespostaPorIdCommand, bool>
    {
        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public ExcluirQuestaoAlunoRespostaPorIdCommandHandler(IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta;
        }
        public async Task<bool> Handle(ExcluirQuestaoAlunoRespostaPorIdCommand request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoResposta.RemoverFisicamenteAsync(request.QuestaoAlunoResposta);
        }
    }
}
