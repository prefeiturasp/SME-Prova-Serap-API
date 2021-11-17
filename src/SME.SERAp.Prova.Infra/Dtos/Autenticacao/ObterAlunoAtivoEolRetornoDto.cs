using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class ObterAlunoAtivoEolRetornoDto
    {
        public long CodigoAluno { get; set; }
        public int Ano { get; set; }
        public int TipoTurno { get; set; }

        public Modalidade Modalidade { get; set; }
    }
}
