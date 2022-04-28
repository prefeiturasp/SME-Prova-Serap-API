using System;

namespace SME.SERAp.Prova.Infra
{
    public class AlunoRetornoDto : DtoBase
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime UltimoLogin { get; set; }
    }
}
