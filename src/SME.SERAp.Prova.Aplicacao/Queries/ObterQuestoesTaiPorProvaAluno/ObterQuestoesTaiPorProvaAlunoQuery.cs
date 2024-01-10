using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra.Dtos.Questao;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestoesTaiPorProvaAlunoQuery : IRequest<IEnumerable<QuestaoTaiDto>>
    {
        public ObterQuestoesTaiPorProvaAlunoQuery(long provaId, long alunoId)
        {
            ProvaId = provaId;
            AlunoId = alunoId;
        }

        public long ProvaId { get; set; }
        public long AlunoId { get; set; }        
    }

    public class ObterQuestoesTaiPorProvaAlunoQueryValidator : AbstractValidator<ObterQuestoesTaiPorProvaAlunoQuery>
    {
        public ObterQuestoesTaiPorProvaAlunoQueryValidator()
        {
            RuleFor(c => c.ProvaId)
                .GreaterThan(0)
                .WithMessage("O Id da prova deve ser informado para obter as questões TAI do aluno.");
            
            RuleFor(c => c.AlunoId)
                .GreaterThan(0)
                .WithMessage("O Id do aluno deve ser informado para obter as questões TAI do aluno.");            
        }
    }
}