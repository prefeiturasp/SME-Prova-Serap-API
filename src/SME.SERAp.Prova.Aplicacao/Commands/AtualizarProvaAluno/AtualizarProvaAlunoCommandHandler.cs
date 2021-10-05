using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarProvaAlunoCommandHandler : IRequestHandler<AtualizarProvaAlunoCommand, bool>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;

        public AtualizarProvaAlunoCommandHandler(IRepositorioProvaAluno repositorioProvaAluno)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
        }
        public async Task<bool> Handle(AtualizarProvaAlunoCommand request, CancellationToken cancellationToken)
            => await repositorioProvaAluno.SalvarAsync(request.ProvaAluno) > 0;
    }
}
