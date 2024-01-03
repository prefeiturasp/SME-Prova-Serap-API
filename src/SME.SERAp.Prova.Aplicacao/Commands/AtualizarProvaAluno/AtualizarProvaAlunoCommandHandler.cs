using MediatR;
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
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<bool> Handle(AtualizarProvaAlunoCommand request, CancellationToken cancellationToken)
        {
            if (request.ProvaAluno.Status == ProvaStatus.Finalizado ||
                request.ProvaAluno.Status == ProvaStatus.FINALIZADA_AUTOMATICAMENTE_TEMPO ||
                request.ProvaAluno.Status == ProvaStatus.FINALIZADA_OFFLINE)

                request.ProvaAluno.FinalizadoEmServidor = DateTime.Now;

            var chaveProvaAluno = string.Format(CacheChave.AlunoProva, request.ProvaAluno.ProvaId, request.ProvaAluno.AlunoRA);

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirProvaAluno, request.ProvaAluno), cancellationToken);
            await repositorioCache.SalvarRedisAsync(chaveProvaAluno, request.ProvaAluno);

            return true;
        }
    }
}
