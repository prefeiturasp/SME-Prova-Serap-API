using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
   public class IncluirDownloadProvaCommandHandler : IRequestHandler<IncluirDownloadProvaCommand, bool>
    {
      
            private readonly IRepositorioDownloadProvaAluno repositorioDownloadProvaAluno;

        public IncluirDownloadProvaCommandHandler(IRepositorioDownloadProvaAluno repositorioDownloadProvaAluno)
            {
                this.repositorioDownloadProvaAluno = repositorioDownloadProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioDownloadProvaAluno));
            }
        public async Task<bool> Handle(IncluirDownloadProvaCommand request, CancellationToken cancellationToken)
            => await repositorioDownloadProvaAluno.IncluirAsync(new Dominio.DownloadProvaAluno(request.ProvaId,request.AlunoRa, request.DispositivoId,   request.TipoDispositivo, request.ModeloDispositivo, request.Versao, request.Situacao)) > 0;
        }
    }

