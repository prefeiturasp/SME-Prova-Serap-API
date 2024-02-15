using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirProvaAlunoCommandHandler : IRequestHandler<IncluirProvaAlunoCommand, bool>
    {
        private readonly IMediator mediator;

        public IncluirProvaAlunoCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(IncluirProvaAlunoCommand request, CancellationToken cancellationToken)
        {
            var entidade = new ProvaAluno(request.ProvaId, request.Status, request.AlunoRa, request.CriadoEm,
                request.FinalizadoEm, request.TipoDispositivo, request.DispositivoId, DateTime.Now);

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirProvaAluno, entidade), cancellationToken);
            await mediator.Send(new SalvarCacheCommand(string.Format(CacheChave.AlunoProva, request.ProvaId, request.AlunoRa), entidade), cancellationToken);

            return true;
        }
    }
}
