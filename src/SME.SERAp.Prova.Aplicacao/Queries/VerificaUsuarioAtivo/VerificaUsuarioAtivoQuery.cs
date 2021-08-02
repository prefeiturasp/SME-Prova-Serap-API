using FluentValidation;
using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaUsuarioAtivoQuery : IRequest<bool>
    {
        public VerificaUsuarioAtivoQuery(long alunoRA)
        {
            AlunoRA = alunoRA;
        }

        public long AlunoRA { get; set; }
    }
    public class VerificaUsuarioAtivoQueryValidator : AbstractValidator<VerificaUsuarioAtivoQuery>
    {
        public VerificaUsuarioAtivoQueryValidator()
        {
            RuleFor(a => a.AlunoRA)
                .NotEmpty()
                .WithMessage("O RA do aluno é obrigatório.");
        }
    }
}
