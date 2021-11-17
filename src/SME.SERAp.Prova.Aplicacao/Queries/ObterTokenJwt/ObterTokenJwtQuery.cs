using FluentValidation;
using MediatR;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTokenJwtQuery : IRequest<(string, DateTime)>
    {
        public ObterTokenJwtQuery(long alunoRA, int alunoAno, int alunoTurno, int alunoModalidade)
        {
            AlunoRA = alunoRA;
            AlunoAno = alunoAno;
            AlunoTurno = alunoTurno;
            AlunoModalidade = alunoModalidade;
        }

        public long AlunoRA { get; set; }
        public int AlunoAno { get; set; }
        public int AlunoTurno { get; set; }
        public int AlunoModalidade { get; set; }
    }
    public class ObterTokenJwtQueryValidator : AbstractValidator<ObterTokenJwtQuery>
    {
        public ObterTokenJwtQueryValidator()
        {
            RuleFor(a => a.AlunoRA)
                .NotEmpty()
                .WithMessage("O RA do aluno é obrigatório.");

            RuleFor(a => a.AlunoAno)
                .NotEmpty()
                .WithMessage("O Ano do aluno é obrigatório.");

            RuleFor(a => a.AlunoTurno)
               .NotEmpty()
               .WithMessage("O turno do aluno é obrigatório.");

            RuleFor(a => a.AlunoModalidade)
               .NotEmpty()
               .WithMessage("A modalidade do aluno é obrigatório.");
        }
    }
}
