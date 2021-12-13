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
    public class ExcluirDownloadsProvaAlunoCommandHandler : IRequestHandler<ExcluirDownloadsProvaAlunoCommand, bool>
    {
        private readonly IRepositorioDownloadProvaAluno repositorioDownloadProvaAluno;

        public ExcluirDownloadsProvaAlunoCommandHandler(IRepositorioDownloadProvaAluno repositorioDownloadProvaAluno)
        {
            this.repositorioDownloadProvaAluno = repositorioDownloadProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioDownloadProvaAluno));
        }

        public async Task<bool> Handle(ExcluirDownloadsProvaAlunoCommand request, CancellationToken cancellationToken)
         => await repositorioDownloadProvaAluno.ExcluirDownloadProvaAluno(request.Ids);
    }
}
