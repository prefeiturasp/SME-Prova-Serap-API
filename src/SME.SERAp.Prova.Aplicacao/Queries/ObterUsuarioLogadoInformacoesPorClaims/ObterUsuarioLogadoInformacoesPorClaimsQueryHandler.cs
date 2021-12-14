using MediatR;
using Microsoft.AspNetCore.Http;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioLogadoInformacoesPorClaimsQueryHandler : IRequestHandler<ObterUsuarioLogadoInformacoesPorClaimsQuery, IEnumerable<ParametroDto>>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ObterUsuarioLogadoInformacoesPorClaimsQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<ParametroDto>> Handle(ObterUsuarioLogadoInformacoesPorClaimsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(httpContextAccessor.HttpContext?.User?.Claims?.Where(a => request.Claims.Contains(a.Type))?.Select(c => new ParametroDto() { Chave = c.Type, Valor = c.Value } ?? default));
        }
    }
}
