using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCodigoValidacaoAdmQueryHandler : IRequestHandler<ObterCodigoValidacaoAdmQuery, AutenticacaoUsuarioAdmDto>
    {
        private readonly IRepositorioCache repositorioCache;

        public ObterCodigoValidacaoAdmQueryHandler(IRepositorioCache repositorioCache)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<AutenticacaoUsuarioAdmDto> Handle(ObterCodigoValidacaoAdmQuery request, CancellationToken cancellationToken)
        {
            var chave = $"auth-adm-{request.Codigo}";

            var retorno = await repositorioCache.ObterRedisAsync<AutenticacaoUsuarioAdmDto>(chave);
            await repositorioCache.RemoverAsync(chave);

            return retorno;
        }
    }
}
