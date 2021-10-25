using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirAlunoCommandHandler : IRequestHandler<IncluirAlunoCommand, bool>
    {
        private readonly IRepositorioAluno repositorioAluno;

        public IncluirAlunoCommandHandler(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }
        public async Task<bool> Handle(IncluirAlunoCommand request, CancellationToken cancellationToken)
            => await repositorioAluno.IncluirAsync(new Dominio.Aluno(request.Nome, request.RA)) > 0;
    }
}
