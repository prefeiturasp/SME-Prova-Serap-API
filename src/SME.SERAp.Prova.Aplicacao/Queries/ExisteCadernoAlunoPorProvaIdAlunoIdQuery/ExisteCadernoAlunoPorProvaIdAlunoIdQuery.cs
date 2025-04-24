using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries
{
    public class ExisteCadernoAlunoPorProvaIdAlunoIdQuery : IRequest<bool>
    {
        public ExisteCadernoAlunoPorProvaIdAlunoIdQuery(long provaId, long alunoId)
        {
            ProvaId = provaId;
            AlunoId = alunoId;
        }

        public long ProvaId { get; }
        public long AlunoId { get; }
    }

    public class ExisteCadernoAlunoPorProvaIdAlunoIdQueryValidator : AbstractValidator<ExisteCadernoAlunoPorProvaIdAlunoIdQuery>
    {
        public ExisteCadernoAlunoPorProvaIdAlunoIdQueryValidator()
        {
            RuleFor(x => x.ProvaId)
                .GreaterThan(0)
                .WithMessage(" Informe o id da prova para verificar se existe o caderno do aluno");

            RuleFor(x => x.AlunoId)
                .GreaterThan(0)
                .WithMessage(" Informe o id do aluno para verificar se existe o caderno do aluno");
        }
    }
}

