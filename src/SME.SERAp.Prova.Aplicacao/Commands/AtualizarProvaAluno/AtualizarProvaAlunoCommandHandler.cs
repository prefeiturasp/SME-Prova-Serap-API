﻿using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarProvaAlunoCommandHandler : IRequestHandler<AtualizarProvaAlunoCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IRepositorioCache repositorioCache;

        public AtualizarProvaAlunoCommandHandler(IRepositorioCache repositorioCache, IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));

        }

        public async Task<bool> Handle(AtualizarProvaAlunoCommand request, CancellationToken cancellationToken)
        {
            if(request.ProvaAluno.Status == ProvaStatus.Finalizado)
            {
                request.ProvaAluno.FinalizadoEmServidor = DateTime.Now;
            }

            string chaveProvaAluno = string.Format(CacheChave.AlunoProva, request.ProvaAluno.ProvaId, request.ProvaAluno.AlunoRA);
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirProvaAluno, request.ProvaAluno));
            await repositorioCache.SalvarRedisAsync(chaveProvaAluno, request.ProvaAluno);
            return true;
        }
    }
}
