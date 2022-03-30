using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class GerarCodigoValidacaoAdmCommandHandler : IRequestHandler<GerarCodigoValidacaoAdmCommand, AutenticacaoValidarAdmDto>
    {
        private readonly IRepositorioCache repositorioCache;

        public GerarCodigoValidacaoAdmCommandHandler(IRepositorioCache repositorioCache)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<AutenticacaoValidarAdmDto> Handle(GerarCodigoValidacaoAdmCommand request, CancellationToken cancellationToken)
        {
            var codigo = Guid.NewGuid();
            var autenticacao = new AutenticacaoUsuarioAdmDto(request.Login, request.Nome, request.Perfil);
            await repositorioCache.SalvarRedisAsync($"auth-adm-{codigo}", autenticacao, 5);
            return new AutenticacaoValidarAdmDto(codigo.ToString());
        }
    }
}
