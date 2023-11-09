using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoDadosPorRaQuery : IRequest<AlunoDetalheDto>
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
                .GreaterThan(0)
                .WithMessage("O RA do aluno é obrigatório.");
        }
    }
}
