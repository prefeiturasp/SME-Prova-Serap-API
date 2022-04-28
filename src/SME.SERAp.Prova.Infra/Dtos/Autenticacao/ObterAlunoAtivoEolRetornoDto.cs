using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class ObterAlunoAtivoEolRetornoDto : DtoBase
    {
        public long CodigoAluno { get; set; }
        public string Ano { get; set; }
        public int TipoTurno { get; set; }

        public Modalidade Modalidade { get; set; }
    }
}
