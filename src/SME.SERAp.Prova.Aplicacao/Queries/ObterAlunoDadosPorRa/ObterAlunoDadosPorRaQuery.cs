using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoDadosPorRaQuery : IRequest<AlunoEol>
    {
        public ObterAlunoDadosPorRaQuery(long alunoRa)
        {
            AlunoRa = alunoRa;
        }

        public long AlunoRa { get; set; }
    }
    public class ObterAlunoDadosPorRaValidator : AbstractValidator<ObterAlunoDadosPorRaQuery>
    {
        public ObterAlunoDadosPorRaValidator()
        {
            RuleFor(a => a.AlunoRa)
                .NotEmpty()
                .WithMessage("O RA do aluno é obrigatório.");
        }
    }
}
