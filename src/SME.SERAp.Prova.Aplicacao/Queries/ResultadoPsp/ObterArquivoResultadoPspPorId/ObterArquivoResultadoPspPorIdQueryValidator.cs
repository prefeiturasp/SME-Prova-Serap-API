using FluentValidation;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoResultadoPspPorIdQueryValidator : AbstractValidator<ObterArquivoResultadoPspPorIdQuery>
    {
        public ObterArquivoResultadoPspPorIdQueryValidator()
        {
            RuleFor(a => a.Id)
               .NotEmpty()
               .WithMessage("O Id do processo é obrigatório.");
        }
    }
}
