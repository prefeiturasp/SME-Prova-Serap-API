using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterAlunoAtivoRetornoDto
    {
        public long Ra { get; set; }
        public string Ano { get; set; }
        public int TipoTurno { get; set; }
        public Modalidade Modalidade { get; set; }
        public long? TurmaId { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
