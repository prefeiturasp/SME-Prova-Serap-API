using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorQuestaoIdRaQueryHandler : IRequestHandler<ObterProvaAlunoPorQuestaoIdRaQuery, ProvaAluno>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;

        public ObterProvaAlunoPorQuestaoIdRaQueryHandler(IRepositorioProvaAluno repositorioProvaAluno)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
        }
        public async Task<ProvaAluno> Handle(ObterProvaAlunoPorQuestaoIdRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProvaAluno.ObterPorQuestaoIdRaAsync(request.QuestaoId, request.AlunoRa);
        }
    }
}
