using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries
{
    public class ExisteCadernoAlunoPorProvaIdAlunoIdQueryHandler : IRequestHandler<ExisteCadernoAlunoPorProvaIdAlunoIdQuery, bool>
    {
        private readonly IRepositorioCadernoAluno repositorioCadernoAluno;

        public ExisteCadernoAlunoPorProvaIdAlunoIdQueryHandler(IRepositorioCadernoAluno repositorioCadernoAluno)
        {
            this.repositorioCadernoAluno = repositorioCadernoAluno ?? throw new ArgumentNullException(nameof(repositorioCadernoAluno));
        }

        public async Task<bool> Handle(ExisteCadernoAlunoPorProvaIdAlunoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCadernoAluno.ExisteCadernoAlunoPorProvaIdAlunoId(request.ProvaId, request.AlunoId);
        }
    }
}
