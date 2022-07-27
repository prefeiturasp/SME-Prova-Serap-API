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
        private readonly IRepositorioCache repositorioCache;
        private readonly IMediator mediator;

        public AtualizarProvaAlunoCommandHandler(IRepositorioCache repositorioCache, IMediator mediator)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Handle(AtualizarProvaAlunoCommand request, CancellationToken cancellationToken)
        {
            string chaveProvaAluno = request.ProvaAluno.ProvaId.ToString() + request.ProvaAluno.AlunoRA.ToString();
            if (await repositorioCache.ExisteChaveAsync(chaveProvaAluno))
                await repositorioCache.RemoverRedisAsync(chaveProvaAluno);

            await repositorioCache.SalvarRedisAsync(chaveProvaAluno, request.ProvaAluno);
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirProvaAluno, request.ProvaAluno));
        }
    }
}
