using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarPreferenciasAlunoCacheCommand : IRequest<bool>
    {
        public AtualizarPreferenciasAlunoCacheCommand(MeusDadosRetornoDto dto, long alunoRa)
        {
            Dto = dto;
            AlunoRA = alunoRa;
        }

        public MeusDadosRetornoDto Dto { get; set; }
        public long AlunoRA { get; set; }
    }

    public class AtualizarPreferenciasAlunoCacheCommandValidator : AbstractValidator<AtualizarPreferenciasAlunoCacheCommand>
    {
        public AtualizarPreferenciasAlunoCacheCommandValidator()
        {
            RuleFor(c => c.Dto)
               .NotEmpty()
               .WithMessage("O dto de MeusDadosRetornoDto precisa ser informado");
        }
    }
}
