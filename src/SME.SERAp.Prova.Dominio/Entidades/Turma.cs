using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dominio
{
    public class Turma : EntidadeBase
    {
        public Turma()
        {

        }

        public string Ano { get; set; }
        public int AnoLetivo { get; set; }
        public int TipoTurma { get; set; }
        public int Modalidade { get; set; }
        public long TipoTurno { get; set; }
        public int Semestre { get; set; }
        public int EtapaEja { get; set; }
        public string SerieEnsino { get; set; }
    }
}
