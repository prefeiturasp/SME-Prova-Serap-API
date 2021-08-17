using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioLogadoInformacaoPorClaimQueryHandler : IRequestHandler<ObterUsuarioLogadoInformacaoPorClaimQuery, string>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ObterUsuarioLogadoInformacaoPorClaimQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        public async Task<string> Handle(ObterUsuarioLogadoInformacaoPorClaimQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(a => a.Type == request.Claim)?.Value ?? string.Empty);
        }
    }
}
