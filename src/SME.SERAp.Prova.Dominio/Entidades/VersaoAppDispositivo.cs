using System;

namespace SME.SERAp.Prova.Dominio
{
    public class VersaoAppDispositivo : EntidadeBase
    {
        public VersaoAppDispositivo(int versaoCodigo, string versaoDescricao, string dispositivoImei, DateTime atualizadoEm)
        {
            VersaoCodigo = versaoCodigo;
            VersaoDescricao = versaoDescricao;
            DispositivoImei = dispositivoImei;
            AtualizadoEm = atualizadoEm;
            CriadoEm = DateTime.Now;
        }

        public int VersaoCodigo { get; set; }
        public string VersaoDescricao { get; set; }
        public string DispositivoImei { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
