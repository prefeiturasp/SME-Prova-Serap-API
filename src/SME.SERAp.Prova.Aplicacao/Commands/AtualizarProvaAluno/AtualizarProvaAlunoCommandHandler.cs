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

        public AtualizarProvaAlunoCommandHandler(IRepositorioCache repositorioCache, IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Handle(AtualizarProvaAlunoCommand request, CancellationToken cancellationToken)
        {
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirProvaAluno, request.ProvaAluno));
        }
    }
}
