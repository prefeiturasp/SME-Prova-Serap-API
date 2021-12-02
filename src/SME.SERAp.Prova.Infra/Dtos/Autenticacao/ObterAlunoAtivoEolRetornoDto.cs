using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class ObterAlunoAtivoEolRetornoDto
    {
        public long CodigoAluno { get; set; }
        public string Ano { get; set; }
        public string NomeAluno { get; set; }
        public int TipoTurno { get; set; }
        public long TurmaCodigo { get; set; }
        public string UeCodigo { get; set; }

        public Modalidade Modalidade { get; set; }
    }
}
