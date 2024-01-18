using MediatR;
using SME.SERAp.Prova.Aplicacao.Queries.VerificaStatusProvaFinalizada;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarProvaAlunoCommandHandler : IRequestHandler<AtualizarProvaAlunoCommand, bool>
    {
        private readonly IMediator mediator;

        public AtualizarProvaAlunoCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(AtualizarProvaAlunoCommand request, CancellationToken cancellationToken)
        {
            if (await mediator.Send(new VerificaStatusProvaFinalizadoQuery(request.ProvaAluno.Status), cancellationToken))
                request.ProvaAluno.FinalizadoEmServidor = DateTime.Now;

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirProvaAluno, request.ProvaAluno), cancellationToken);
            await mediator.Send(new SalvarCacheCommand(string.Format(CacheChave.AlunoProva, request.ProvaAluno.ProvaId, request.ProvaAluno.AlunoRA), request.ProvaAluno), cancellationToken);            

            return true;
        }
    }
}
