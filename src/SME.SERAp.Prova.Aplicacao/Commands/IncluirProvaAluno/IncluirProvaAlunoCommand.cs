using MediatR;
using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirProvaAlunoCommand : IRequest<bool>
    {
        public IncluirProvaAlunoCommand(long provaId, long alunoRa, ProvaStatus status, DateTime criadoEm, DateTime? finalizadoEm, TipoDispositivo tipoDispositivo, string dispositivoId)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
            Status = status;
            FinalizadoEm = finalizadoEm;
            CriadoEm = criadoEm;
            TipoDispositivo = tipoDispositivo;
            DispositivoId = dispositivoId;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
        public ProvaStatus Status { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public DateTime CriadoEm { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public string DispositivoId { get; set; }
    }
}
