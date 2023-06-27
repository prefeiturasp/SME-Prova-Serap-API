using FluentValidation;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaExtracaoPorLegadoIdQueryValidator : AbstractValidator<ObterProvaExtracaoPorLegadoIdQuery>
    {
        public ObterProvaExtracaoPorLegadoIdQueryValidator()
        {
            RuleFor(x => x.ProvaLegadoId).NotNull().WithMessage("O id da prova deve ser informado");
        }
    }
}
