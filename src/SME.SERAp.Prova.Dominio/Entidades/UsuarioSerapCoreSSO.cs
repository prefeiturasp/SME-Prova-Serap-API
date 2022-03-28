using System;

namespace SME.SERAp.Prova.Dominio
{
    public class UsuarioSerapCoreSSO : EntidadeBase
    {
        public Guid IdCoreSSO { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
