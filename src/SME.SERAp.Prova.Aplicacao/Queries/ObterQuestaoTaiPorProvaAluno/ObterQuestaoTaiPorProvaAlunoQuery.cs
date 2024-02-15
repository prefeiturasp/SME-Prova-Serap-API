using MediatR;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using System.Collections.Generic;
using FluentValidation;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoTaiPorProvaAlunoQuery : IRequest<IEnumerable<QuestaoTaiDto>>
    {
        public ObterQuestaoTaiPorProvaAlunoQuery(long provaId, long alunoRa)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
        }

        public long ProvaId { get; }
        public long AlunoRa { get; }
    }

    public class ObterQuestaoTaiPorProvaAlunoQueryValidator : AbstractValidator<ObterQuestaoTaiPorProvaAlunoQuery>
    {
        public ObterQuestaoTaiPorProvaAlunoQueryValidator()
        {
            RuleFor(c => c.ProvaId)
                .GreaterThan(0)
                .WithMessage("O Id da prova deve ser informado para obter as questões TAI do aluno.");
            
            RuleFor(c => c.AlunoRa)
                .GreaterThan(0)
                .WithMessage("O RA do aluno deve ser informado para obter as questões TAI do aluno.");            
        }
    }
}
