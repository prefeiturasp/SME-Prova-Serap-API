using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorProvaIdRaStatusQueryHandler : IRequestHandler<ObterProvaAlunoPorProvaIdRaStatusQuery, ProvaAluno>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;

        public ObterProvaAlunoPorProvaIdRaStatusQueryHandler(IRepositorioProvaAluno repositorioProvaAluno)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
        }
        public async Task<ProvaAluno> Handle(ObterProvaAlunoPorProvaIdRaStatusQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProvaAluno.ObterPorProvaIdRaStatusAsync(request.ProvaId, request.AlunoRa, request.Status);
        }
    }
}
