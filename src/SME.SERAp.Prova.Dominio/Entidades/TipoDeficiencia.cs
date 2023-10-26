using System;

namespace SME.SERAp.Prova.Dominio
{
    public class TipoDeficiencia : EntidadeBase
    {
        public TipoDeficiencia()
        {

        }

        public Guid LegadoId { get; set; }
        public int CodigoEol { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool ProvaNormal { get; set; }
    }
}
