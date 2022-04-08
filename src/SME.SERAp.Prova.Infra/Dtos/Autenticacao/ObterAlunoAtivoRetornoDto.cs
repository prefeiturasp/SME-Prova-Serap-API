using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class ObterAlunoAtivoRetornoDto
    {
        public long Ra { get; set; }
        public string Ano { get; set; }
        public int TipoTurno { get; set; }
        public Modalidade Modalidade { get; set; }
    }
}
