using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirUsuarioDispositivoCommand : IRequest<bool>
    {
        public IncluirUsuarioDispositivoCommand(long ra, string dispositivoId, int ano)
        {
            Ra = ra;
            DispositivoId = dispositivoId;
            Ano = ano;
        }

        public long Ra { get; set; }
        public string DispositivoId { get; set; }
        public int Ano { get; set; }
    }
}
