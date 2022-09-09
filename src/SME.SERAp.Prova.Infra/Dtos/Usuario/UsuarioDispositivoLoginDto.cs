using System;

namespace SME.SERAp.Prova.Infra
{
    public class UsuarioDispositivoLoginDto
    {
        public UsuarioDispositivoLoginDto()
        {

        }

        public UsuarioDispositivoLoginDto(long ra, string dispositivoId, long? turmaId)
        {
            Ra = ra;
            DispositivoId = dispositivoId;
            CriadoEm = DateTime.Now;
            TurmaId = turmaId;
        }

        public long Ra { get; set; }
        public string DispositivoId { get; set; }
        public DateTime CriadoEm { get; set; }
        public long? TurmaId { get; set; }
    }
}
