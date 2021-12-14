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
  public  class IncluirDownloadProvaCommand : IRequest<long>
    {
        public IncluirDownloadProvaCommand(long alunoRa, DownloadProvaAlunoDto downloadProvaAlunoDto)
        {
            AlunoRa = alunoRa;
            DownloadProvaAlunoDto = downloadProvaAlunoDto;
            Situacao = 1;
            
        }

        public DownloadProvaAlunoDto DownloadProvaAlunoDto { get; set; }
        public long AlunoRa { get; set; }
        public int Situacao { get; set; }

    }
}

