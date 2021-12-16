using SME.SERAp.Prova.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dominio
{
    public class DownloadProvaAluno : EntidadeBase
    {
        public DownloadProvaAluno(long provaId, long alunoRa, string dispositivoId, TipoDispositivo tipoDispositivo, string modeloDispositivo, string versao, int situacao, DateTime criadoEm)
        {
            AlunoRA = alunoRa;
            ProvaId = provaId;
            DispositivoId = dispositivoId;
            TipoDispositivo = tipoDispositivo;
            ModeloDispositivo = modeloDispositivo;
            Situacao = situacao;
            Versao = versao;
            CriadoEm = criadoEm;
        }


        public long ProvaId { get; set; }
        public long AlunoRA { get; set; }
        public int Situacao { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public string DispositivoId { get; set; }
        public string ModeloDispositivo { get; set; }
        public string Versao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }

    }
}
