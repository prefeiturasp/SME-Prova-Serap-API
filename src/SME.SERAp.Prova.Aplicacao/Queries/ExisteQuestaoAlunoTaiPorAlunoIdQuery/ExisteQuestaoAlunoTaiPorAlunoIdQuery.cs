using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries
{
    public class ExisteQuestaoAlunoTaiPorAlunoIdQuery : IRequest<bool>
    {
        public ExisteQuestaoAlunoTaiPorAlunoIdQuery(long provaId, long alunoId)
        {
            ProvaId = provaId;
            AlunoId = alunoId;
        }
        public long AlunoId { get; }
        public long ProvaId { get; }
    }

    public class ExisteQuestaoAlunoTaiPorAlunoIdQueryValidator : AbstractValidator<ExisteQuestaoAlunoTaiPorAlunoIdQuery>
    {
        public ExisteQuestaoAlunoTaiPorAlunoIdQueryValidator()
        {

            RuleFor(x => x.ProvaId)
                .GreaterThan(0)
                .WithMessage(" Informe o id da prova para verificar se existe o prova do aluno");

            RuleFor(x => x.AlunoId)
                .GreaterThan(0)
                .WithMessage(" Informe o id do aluno para verificar se existe o caderno do aluno");
        }
    }
}
