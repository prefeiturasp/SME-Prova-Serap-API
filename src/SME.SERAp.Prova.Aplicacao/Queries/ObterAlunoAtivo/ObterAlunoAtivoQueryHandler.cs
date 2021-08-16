using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoAtivoQueryHandler : IRequestHandler<ObterAlunoAtivoQuery, ObterAlunoAtivoRetornoDto>
    {
        private readonly IRepositorioAluno repositorioAluno;

        public ObterAlunoAtivoQueryHandler(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }
        public async Task<ObterAlunoAtivoRetornoDto> Handle(ObterAlunoAtivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAluno.ObterAlunoAtivoAsync(request.AlunoRA);
        }
    }
}
