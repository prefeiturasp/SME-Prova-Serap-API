using FluentValidation;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaExecucaoControleTipoPorTipoQueryValidator : AbstractValidator<ObterUltimaExecucaoControleTipoPorTipoQuery>
    {
        public ObterUltimaExecucaoControleTipoPorTipoQueryValidator()
        {
            RuleFor(a => a.Tipo)
                .NotEmpty()
                .WithMessage("O tipo é obrigatório.");
        }
    }
}
