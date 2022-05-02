using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Infra;
using System;

public class IncluirVersaoAppDispositivoCommand : IRequest<bool>
{
    public IncluirVersaoAppDispositivoCommand(VersaoAppDispositivoDto versaoAppDispositivo)
    {
        VersaoAppDispositivo = versaoAppDispositivo;
    }

    public VersaoAppDispositivoDto VersaoAppDispositivo { get; set; }
}

public class IncluirVersaoAppDispositivoCommandValidator : AbstractValidator<IncluirVersaoAppDispositivoCommand>
{
    public IncluirVersaoAppDispositivoCommandValidator()
    {
        RuleFor(c => c.VersaoAppDispositivo.VersaoDescricao)
           .NotEmpty()
           .WithMessage("A Descrição da versão deve ser informado.");

        RuleFor(c => c.VersaoAppDispositivo.DispositivoImei)
           .NotEmpty()
           .WithMessage("O Código IMEI do dispositivo deve ser informado.");

        RuleFor(c => c.VersaoAppDispositivo.AtualizadoEm)
            .NotEmpty()
            .WithMessage("A data e hora em que o dispositivo foi atualizado deve ser informado.");
    }
}