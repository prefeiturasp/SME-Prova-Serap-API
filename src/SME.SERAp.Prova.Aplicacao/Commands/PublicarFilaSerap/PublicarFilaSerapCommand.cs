using FluentValidation;
using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PublicarFilaSerapCommand : IRequest<bool>
    {
        public PublicarFilaSerapCommand(string fila, object mensagem)
        {
            Fila = fila;
            Mensagem = mensagem;
        }

        public string Fila { get; set; }
        public object Mensagem { get; set; }
    }

    public class PublicarFilaSerapCommandValidator : AbstractValidator<PublicarFilaSerapCommand>
    {
        public PublicarFilaSerapCommandValidator()
        {
            RuleFor(c => c.Fila)
               .NotEmpty()
               .WithMessage("O nome da fila deve ser informado para publicar na fila do Serap.");

            RuleFor(c => c.Mensagem)
               .NotEmpty()
               .WithMessage("O objeto da mensagem ser informado para publicar na fila do Serap.");

        }
    }
}
