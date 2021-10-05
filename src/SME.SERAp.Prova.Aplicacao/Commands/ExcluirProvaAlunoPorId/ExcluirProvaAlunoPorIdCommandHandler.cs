using MediatR;
using SME.SERAp.Prova.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExcluirProvaAlunoPorIdCommandHandler : IRequestHandler<ExcluirProvaAlunoPorIdCommand, bool>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;

        public ExcluirProvaAlunoPorIdCommandHandler(IRepositorioProvaAluno repositorioProvaAluno)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
        }
        public async Task<bool> Handle(ExcluirProvaAlunoPorIdCommand request, CancellationToken cancellationToken)
        {
            return await repositorioProvaAluno.RemoverFisicamenteAsync(request.ProvaAluno);
        }
    }
}
