using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class GerarCodigoValidacaoAdmCommandHandler : IRequestHandler<GerarCodigoValidacaoAdmCommand, string>
    {
        private readonly IRepositorioCache repositorioCache;

        public GerarCodigoValidacaoAdmCommandHandler(IRepositorioCache repositorioCache)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<string> Handle(GerarCodigoValidacaoAdmCommand request, CancellationToken cancellationToken)
        {
            var codigo = Guid.NewGuid();
            await repositorioCache.SalvarRedisAsync($"auth-adm-{codigo}", request, 5);
            return codigo.ToString();
        }
    }
}
