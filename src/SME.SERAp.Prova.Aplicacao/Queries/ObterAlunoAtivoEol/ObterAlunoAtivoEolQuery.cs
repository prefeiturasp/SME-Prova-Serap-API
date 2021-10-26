using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoAtivoEolQuery : IRequest<ObterAlunoAtivoEolRetornoDto>
    {
        public ObterAlunoAtivoEolQuery(long alunoRA)
        {
            AlunoRA = alunoRA;
        }

        public long AlunoRA { get; set; }
    }
    public class ObterAlunoAtivoEolQueryValidator : AbstractValidator<ObterAlunoAtivoEolQuery>
    {
        public ObterAlunoAtivoEolQueryValidator()
        {
            RuleFor(a => a.AlunoRA)
                .NotEmpty()
                .WithMessage("O RA do aluno é obrigatório.");
        }
    }
}
