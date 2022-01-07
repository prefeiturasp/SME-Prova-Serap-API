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

        public int Ano { get; set; }
        public int AnoLetivo { get; set; }
        public int TipoTurma { get; set; }
        public int Modalidade { get; set; }
        public long TipoTurno { get; set; }
    }
}
