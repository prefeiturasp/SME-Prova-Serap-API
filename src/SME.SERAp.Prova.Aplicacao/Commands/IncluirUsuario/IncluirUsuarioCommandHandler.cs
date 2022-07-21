using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirUsuarioCommandHandler : IRequestHandler<IncluirUsuarioCommand, bool>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IMediator mediator;

        public IncluirUsuarioCommandHandler(IRepositorioCache repositorioCache,
                                            IMediator mediator)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Handle(IncluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usurioDto = new UsuarioDto
            {
                Login = request.Login,
                Nome = request.Nome
            };
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirUsuario, usurioDto));
            await repositorioCache.SalvarRedisAsync(request.Login.ToString(), new Dominio.Usuario(request.Nome, request.Login));
            return true;
        }

    }
}
