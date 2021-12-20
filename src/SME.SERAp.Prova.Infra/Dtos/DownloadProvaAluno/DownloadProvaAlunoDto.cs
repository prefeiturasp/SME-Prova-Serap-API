using SME.SERAp.Prova.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra
{
    public class DownloadProvaAlunoDto
    {
        public long ProvaId { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public string DispositivoId { get; set; }
        public string ModeloDispositivo { get; set; }
        public string Versao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
