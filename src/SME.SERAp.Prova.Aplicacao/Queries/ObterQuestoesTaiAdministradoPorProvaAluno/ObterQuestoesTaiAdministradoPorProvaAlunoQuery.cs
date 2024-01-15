using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra.Dtos.Questao;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestoesTaiAdministradoPorProvaAlunoQuery : IRequest<IEnumerable<QuestaoTaiDto>>
    {
        public ObterQuestoesTaiAdministradoPorProvaAlunoQuery(long provaId, long alunoId)
        {
            ProvaId = provaId;
            AlunoId = alunoId;
        }

        public long ProvaId { get; }
        public long AlunoId { get; }        
    }

    public class ObterQuestoesTaiAdministradoPorProvaAlunoQueryValidator : AbstractValidator<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>
    {
        public ObterQuestoesTaiAdministradoPorProvaAlunoQueryValidator()
        {
            RuleFor(c => c.ProvaId)
                .GreaterThan(0)
                .WithMessage("O Id da prova deve ser informado para obter o administrado das questões TAI do aluno.");
            
            RuleFor(c => c.AlunoId)
                .GreaterThan(0)
                .WithMessage("O Id do aluno deve ser informado para obter o administrado das questões TAI do aluno.");            
        }
    }
}