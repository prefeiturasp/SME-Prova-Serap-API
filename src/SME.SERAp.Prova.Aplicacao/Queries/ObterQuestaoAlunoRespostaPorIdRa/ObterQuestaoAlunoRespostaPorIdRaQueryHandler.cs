using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoAlunoRespostaPorIdRaQueryHandler : IRequestHandler<ObterQuestaoAlunoRespostaPorIdRaQuery, QuestaoAlunoResposta>
    {
        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public ObterQuestaoAlunoRespostaPorIdRaQueryHandler(IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoAlunoResposta));
        }
        public async Task<QuestaoAlunoResposta> Handle(ObterQuestaoAlunoRespostaPorIdRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoResposta.ObterPorIdRaAsync(request.QuestaoId, request.AlunoRa);
        }
    }
}
