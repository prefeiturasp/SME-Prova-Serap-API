using System;

namespace SME.SERAp.Prova.Dominio
{
    public class UsuarioDispositivo : EntidadeBase
    {
        public UsuarioDispositivo()
        {
            CriadoEm = DateTime.Now;
        }

        public UsuarioDispositivo(string dispositivoId, long ra, int ano)
        {
            DispositivoId = dispositivoId;
            Ra = ra;
            Ano = ano;
            CriadoEm = DateTime.Now;
        }

        public string DispositivoId { get; set; }
        public long Ra { get; set; }
        public int Ano { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
