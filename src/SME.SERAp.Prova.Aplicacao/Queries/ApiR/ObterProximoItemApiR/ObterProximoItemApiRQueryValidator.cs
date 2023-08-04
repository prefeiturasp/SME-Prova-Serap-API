using FluentValidation;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProximoItemApiRQueryValidator : AbstractValidator<ObterProximoItemApiRQuery>
    {
        public ObterProximoItemApiRQueryValidator()
        {
            RuleFor(c => c.Estudante)
                .NotNull()
                .NotEmpty()
                .WithMessage("O estudante deve ser informado.");

            RuleFor(c => c.AnoEscolarEstudante)
                .NotNull()
                .NotEmpty()
                .WithMessage("O ano escolar do estudante deve ser informado.");

            RuleFor(c => c.Proficiencia)
                .GreaterThan(decimal.Zero)
                .WithMessage("A proficiência deve ser informada.");

            RuleFor(c => c.Componente)
                .NotNull()
                .NotEmpty()
                .WithMessage("O componente deve ser informado.");

            RuleFor(c => c.IdItem)
                .Must(c => c is { Length: > 0 })
                .WithMessage("Os items utilizados na aplicação devem ser informados.");
            
            RuleFor(c => c.ParA)
                .Must(c => c is { Length: > 0 })
                .WithMessage("Os parâmetros de discriminação devem ser informados.");
            
            RuleFor(c => c.ParB)
                .Must(c => c is { Length: > 0 })
                .WithMessage("Os parâmetros de dificuldade devem ser informados.");            
            
            RuleFor(c => c.ParC)
                .Must(c => c is { Length: > 0 })
                .WithMessage("Os parâmetros de acerto ao acaso devem ser informados.");

            RuleFor(c => c.NIj)
                .GreaterThan(0)
                .WithMessage("A quantidade de itens que compõe a amostra deve ser informada.");
        }
    }
}