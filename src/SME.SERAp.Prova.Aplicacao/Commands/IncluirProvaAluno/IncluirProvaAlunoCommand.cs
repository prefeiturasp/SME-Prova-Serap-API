using MediatR;
using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirProvaAlunoCommand : IRequest<bool>
    {
        public IncluirProvaAlunoCommand(long provaId, long alunoRa, ProvaStatus status)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
            Status = status;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
        public ProvaStatus Status { get; set; }
    }
}
