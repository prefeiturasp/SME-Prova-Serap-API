using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoSerapPorRaQueryHandler : IRequestHandler<ObterAlunoSerapPorRaQuery, Aluno>
    {
        private readonly IRepositorioAluno repositorioAluno;

        public ObterAlunoSerapPorRaQueryHandler(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }
        public async Task<Aluno> Handle(ObterAlunoSerapPorRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAluno.ObterPorRA(request.AlunoRA);
        }
    }
}
