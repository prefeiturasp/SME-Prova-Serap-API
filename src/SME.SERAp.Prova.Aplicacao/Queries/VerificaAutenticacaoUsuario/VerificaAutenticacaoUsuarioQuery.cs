using FluentValidation;
using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaAutenticacaoUsuarioQuery : IRequest<bool>
    {
        public VerificaAutenticacaoUsuarioQuery(long alunoRA, string senha)
        {
            AlunoRA = alunoRA;
            Senha = senha;
        }

        public long AlunoRA { get; set; }
        public string Senha { get; set; }
    }
    public class VerificaAutenticacaoUsuarioQueryValidator : AbstractValidator<VerificaAutenticacaoUsuarioQuery>
    {
        public VerificaAutenticacaoUsuarioQueryValidator()
        {
            RuleFor(a => a.AlunoRA)
                .NotEmpty()
                .WithMessage("O RA do aluno é obrigatório.");

            RuleFor(a => a.Senha)
                .NotEmpty()
                .WithMessage("O senha do aluno é obrigatório.");
        }
    }
}
