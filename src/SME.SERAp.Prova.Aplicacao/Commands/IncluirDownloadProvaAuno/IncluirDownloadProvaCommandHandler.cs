﻿using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirDownloadProvaCommandHandler : IRequestHandler<IncluirDownloadProvaCommand, long>
    {

        private readonly IRepositorioDownloadProvaAluno repositorioDownloadProvaAluno;

        public IncluirDownloadProvaCommandHandler(IRepositorioDownloadProvaAluno repositorioDownloadProvaAluno)
        {
            this.repositorioDownloadProvaAluno = repositorioDownloadProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioDownloadProvaAluno));
        }
        public async Task<long> Handle(IncluirDownloadProvaCommand request, CancellationToken cancellationToken)
            => await repositorioDownloadProvaAluno.IncluirAsync(new Dominio.DownloadProvaAluno(request.DownloadProvaAlunoDto.ProvaId,
                request.AlunoRa,
                request.DownloadProvaAlunoDto.DispositivoId,
                request.DownloadProvaAlunoDto.TipoDispositivo,
                request.DownloadProvaAlunoDto.ModeloDispositivo,
                request.DownloadProvaAlunoDto.Versao,
                request.Situacao,
                request.DownloadProvaAlunoDto.DataHora.AddHours(3))
                );
    }
}

