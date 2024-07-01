using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasEmAndamentoPorQuestaoIdQuery : IRequest<IEnumerable<ProvaQuestaoDto>>
    {
        public ObterProvasEmAndamentoPorQuestaoIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }

        public long QuestaoId { get; }
    }

    public class ObterProvasEmAndamentoPorQuestaoIdQueryValidator : AbstractValidator<ObterProvasEmAndamentoPorQuestaoIdQuery>
    {
        public ObterProvasEmAndamentoPorQuestaoIdQueryValidator()
        {
            RuleFor(c => c.QuestaoId)
                .GreaterThan(0)
                .WithMessage("O Id da questão deve ser informado para obter as provas em andamento.");
        }
    }
}