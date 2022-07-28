using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirProvaAlunoCommandHandler : IRequestHandler<IncluirProvaAlunoCommand, bool>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IMediator mediator;
     

        public IncluirProvaAlunoCommandHandler(IRepositorioCache repositorioCache, IMediator mediator)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Handle(IncluirProvaAlunoCommand request, CancellationToken cancellationToken)
        {
          
            var entidade = new ProvaAluno(request.ProvaId, request.Status, request.AlunoRa, request.CriadoEm, request.FinalizadoEm, TipoDispositivo.NaoCadastrado);
            string chaveProvaAluno = request.ProvaId.ToString() + request.AlunoRa.ToString();
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirProvaAluno, entidade));
            await repositorioCache.SalvarRedisAsync(chaveProvaAluno, entidade);
            return true;        
        }
    }
}
