using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaAutenticacaoUsuarioQuery : IRequest<bool>
    {
        public VerificaAutenticacaoUsuarioQuery(long alunoRA, string senha, DateTime dataNascimento)
        {
            AlunoRA = alunoRA;
            Senha = senha;
            DataNascimento = dataNascimento;
        }

        public long AlunoRA { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
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
