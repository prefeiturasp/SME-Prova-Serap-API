using MediatR;
using SME.SERAp.Prova.Dominio.Enumerados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
  public  class IncluirDownloadProvaCommand : IRequest<bool>
    {
        public IncluirDownloadProvaCommand(long provaId, long alunoRa, DownloadProvaAlunoDto downloadProvaAlunoDto)
        {
            AlunoRa = alunoRa;
            ProvaId = provaId;
            DispositivoId = downloadProvaAlunoDto.DispositivoId;
            TipoDispositivo = downloadProvaAlunoDto.TipoDispositivo;
            ModeloDispositivo = downloadProvaAlunoDto.ModeloDispositivo;
            Versao = downloadProvaAlunoDto.Versao;
            Situacao = 1;
            
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public string DispositivoId { get; set; }
        public string ModeloDispositivo { get; set; }
        public string Versao { get; set; }
        public int Situacao { get; set; }

    }
}

