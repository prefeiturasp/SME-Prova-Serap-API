using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoAtivoQuery : IRequest<ObterAlunoAtivoRetornoDto>
    {
        public ObterAlunoAtivoQuery(long alunoRA)
        {
            AlunoRA = alunoRA;
        }

        public long AlunoRA { get; set; }
    }
    public class VerificaUsuarioAtivoQueryValidator : AbstractValidator<ObterAlunoAtivoQuery>
    {
        public VerificaUsuarioAtivoQueryValidator()
        {
            RuleFor(a => a.AlunoRA)
                .NotEmpty()
                .WithMessage("O RA do aluno é obrigatório.");
        }
    }
}
