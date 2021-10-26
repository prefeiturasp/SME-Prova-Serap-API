using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarAlunoCommandHandler : IRequestHandler<AtualizarAlunoCommand, bool>
    {
        private readonly IRepositorioAluno repositorioAluno;

        public AtualizarAlunoCommandHandler(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }
        public async Task<bool> Handle(AtualizarAlunoCommand request, CancellationToken cancellationToken)
            => await repositorioAluno.SalvarAsync(request.Aluno) > 0;
    }
}
