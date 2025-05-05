using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Commands
{
    public class QuestaoAlunoTaiIncluirCommand : IRequest<long>
    {
        public QuestaoAlunoTaiIncluirCommand(QuestaoAlunoTai questaoAlunoTai)
        {
            QuestaoAlunoTai = questaoAlunoTai;
        }

        public QuestaoAlunoTai QuestaoAlunoTai { get; }
    }

    public class QuestaoAlunoTaiIncluirCommandValidator : AbstractValidator<QuestaoAlunoTaiIncluirCommand>
    {
        public QuestaoAlunoTaiIncluirCommandValidator()
        {
            RuleFor(c => c.QuestaoAlunoTai)
                .NotNull()
                .WithMessage("Os dados da questão TAI do aluno devem ser informados.")
                .DependentRules(() =>
                {
                    RuleFor(c => c.QuestaoAlunoTai.QuestaoId)
                        .GreaterThan(0)
                        .WithMessage("O Id da questão deve ser informado.");

                    RuleFor(c => c.QuestaoAlunoTai.AlunoId)
                        .GreaterThan(0)
                        .WithMessage("O Id do aluno deve ser informado.");

                    RuleFor(c => c.QuestaoAlunoTai.Ordem)
                        .GreaterThanOrEqualTo(0)
                        .WithMessage("A ordem deve ser maior ou igual a 0 (zero).");

                    RuleFor(c => c.QuestaoAlunoTai.CriadoEm)
                        .NotNull()
                        .WithMessage("A data de criação do registro deve ser informada.");
                });
        }
    }
}
