using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterRAUsuarioLogadoQueryHandler : IRequestHandler<ObterRAUsuarioLogadoQuery , string>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ObterRAUsuarioLogadoQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new System.ArgumentNullException(nameof(httpContextAccessor));
        }
        public async Task<string> Handle(ObterRAUsuarioLogadoQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(a => a.Type == "RA")?.Value ?? string.Empty);
        }
    }
}
