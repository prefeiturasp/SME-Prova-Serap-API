using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioPorLoginQueryValidator : AbstractValidator<ObterUsuarioPorLoginQuery>
    {
        public ObterUsuarioPorLoginQueryValidator()
        {
            RuleFor(a => a.Login)
                .NotEmpty()
                .WithMessage("O RA do aluno é obrigatório.");
        }
    }
}
