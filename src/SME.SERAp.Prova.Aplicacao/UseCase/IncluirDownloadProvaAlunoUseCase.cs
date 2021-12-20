﻿using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirDownloadProvaAlunoUseCase : AbstractUseCase, IIncluirDownloadProvaAlunoUseCase
    {
        private readonly IMediator mediator;
        public IncluirDownloadProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<long> Executar(DownloadProvaAlunoDto downloadProvaAlunoDto)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            return  await mediator.Send(new IncluirDownloadProvaCommand(alunoRa, downloadProvaAlunoDto));
        }
    }
}