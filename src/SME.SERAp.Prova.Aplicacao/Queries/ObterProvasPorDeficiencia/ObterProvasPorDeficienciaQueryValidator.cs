using FluentValidation;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorDeficienciaQueryValidator : AbstractValidator<ObterProvasPorDeficienciaQuery>
    {
        public ObterProvasPorDeficienciaQueryValidator()
        {
            RuleFor(x => x.ProvasId).NotEmpty().WithMessage("Os códigos das Provas é obrigatório");
            RuleFor(x => x.Deficiencias).NotEmpty().WithMessage("As deficiências é obrigatório");
        }
    }
}
