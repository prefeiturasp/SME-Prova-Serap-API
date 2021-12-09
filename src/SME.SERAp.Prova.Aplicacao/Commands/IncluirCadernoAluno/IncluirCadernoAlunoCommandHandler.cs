using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirCadernoAlunoCommandHandler : IRequestHandler<IncluirCadernoAlunoCommand, bool>
    {
        private readonly IRepositorioCadernoAluno repositorioCadernoAluno;

        public IncluirCadernoAlunoCommandHandler(IRepositorioCadernoAluno repositorioCadernoAluno)
        {
            this.repositorioCadernoAluno = repositorioCadernoAluno ?? throw new System.ArgumentNullException(nameof(repositorioCadernoAluno));
        }
        public async Task<bool> Handle(IncluirCadernoAlunoCommand request, CancellationToken cancellationToken)
            => await repositorioCadernoAluno.IncluirAsync(new Dominio.CadernoAluno(request.AlunoId, request.ProvaId, request.Caderno)) > 0;
    }
}
