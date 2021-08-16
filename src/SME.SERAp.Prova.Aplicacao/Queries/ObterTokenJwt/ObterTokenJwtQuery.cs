using FluentValidation;
using MediatR;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTokenJwtQuery : IRequest<(string, DateTime)>
    {
        public ObterTokenJwtQuery(long alunoRA, int alunoAno)
        {
            AlunoRA = alunoRA;
            AlunoAno = alunoAno;
        }

        public long AlunoRA { get; set; }
        public int AlunoAno { get; set; }
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
        }
    }
}
