using System;

namespace SME.SERAp.Prova.Infra
{
    public class VersaoAppDispositivoDto : DtoBase
    {
        public int VersaoCodigo { get; set; }
        public string VersaoDescricao { get; set; }
        public string DispositivoImei { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public string DispositivoId { get; set; }
    }
}
