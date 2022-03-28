using FluentValidation;
using MediatR;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTokenJwtAdmQuery : IRequest<(string, DateTime)>
    {
        public ObterTokenJwtAdmQuery(string login, string nome, Guid perfil)
        {
            Login = login;
            Nome = nome;
            Perfil = perfil;
        }

        public string Login { get; set; }
        public string Nome { get; set; }
        public Guid Perfil { get; set; }
    }

    public class ObterTokenJwtAdmQueryValidator : AbstractValidator<ObterTokenJwtAdmQuery>
    {
        public ObterTokenJwtAdmQueryValidator()
        {
            RuleFor(a => a.Login)
                .NotEmpty()
                .WithMessage("O Login é obrigatório.");
            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório.");
            RuleFor(a => a.Perfil)
                .NotEmpty()
                .WithMessage("O Perfil  obrigatório.");
        }
    }
}

