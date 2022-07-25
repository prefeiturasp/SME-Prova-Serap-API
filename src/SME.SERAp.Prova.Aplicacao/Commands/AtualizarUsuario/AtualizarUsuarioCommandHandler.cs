using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IRepositorioCache repositorioCache;
        private readonly IMediator mediator;

        public AtualizarUsuarioCommandHandler(IMediator mediator, IRepositorioCache repositorioCache)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var existeUsuarioCache = await repositorioCache.ExisteChaveAsync(request.Usuario.Login.ToString());
            if (existeUsuarioCache)
                await repositorioCache.RemoverRedisAsync(request.Usuario.Login.ToString());
            await repositorioCache.SalvarRedisAsync(request.Usuario.Login.ToString(), request.Usuario);
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.AlterarUsuario, request.Usuario));
            return true;
        }

    }
}