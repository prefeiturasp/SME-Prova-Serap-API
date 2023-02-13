using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaResultadoDto
    {
        public decimal? Proficiencia { get; set; }
        public IEnumerable<ProvaResultadoResumoDto> Resumos { get; set; }
    }
}
