using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterRAUsuarioLogadoQueryHandler : IRequestHandler<ObterRAUsuarioLogadoQuery , long>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ObterRAUsuarioLogadoQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new System.ArgumentNullException(nameof(httpContextAccessor));
        }
        public async Task<long> Handle(ObterRAUsuarioLogadoQuery request, CancellationToken cancellationToken)
        {
            var ra = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(a => a.Type == "RA").Value ?? string.Empty;
            return await Task.FromResult(string.IsNullOrEmpty(ra)? 0: long.Parse(ra));
        }
    }
}
