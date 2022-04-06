using System;

namespace SME.SERAp.Prova.Dominio
{
   public class VersaoApp : EntidadeBase
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Mensagem { get; set; }
        public DateTime  CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
        public int SuporteMinimo { get; set; }
        public string Url { get; set; }
    }
}
