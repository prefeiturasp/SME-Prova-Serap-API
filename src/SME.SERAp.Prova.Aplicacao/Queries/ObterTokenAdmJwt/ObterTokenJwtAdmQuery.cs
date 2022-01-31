using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTokenJwtAdmQuery : IRequest<(string, DateTime)>
    {

        public ObterTokenJwtAdmQuery(string login, Guid perfil)
        {
            Login = login;
            Perfil = perfil;
        }
        public string Login { get; set; }
        public Guid Perfil { get; set; }
    }
    public class ObterTokenJwtAdmQueryValidator : AbstractValidator<ObterTokenJwtAdmQuery>
    {
        public ObterTokenJwtAdmQueryValidator()
        {
            RuleFor(a => a.Login)
                .NotEmpty()
                .WithMessage("O Login é obrigatório.");
            RuleFor(a => a.Perfil)
                .NotEmpty()
                .WithMessage("O Perfil  obrigatório.");
        }
    }
}

