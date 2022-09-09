using MediatR;
using Microsoft.AspNetCore.Http;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterDadosAlunoLogadoQueryHandler : IRequestHandler<ObterDadosAlunoLogadoQuery, DadosAlunoLogadoDto>
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        public ObterDadosAlunoLogadoQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new System.ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<DadosAlunoLogadoDto> Handle(ObterDadosAlunoLogadoQuery request, CancellationToken cancellationToken)
        {
            var ra = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(a => a.Type == "RA").Value ?? string.Empty;
            var dispositivoId = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(a => a.Type == "DISPOSITIVO_ID")?.Value ?? string.Empty;
            var dadosAluno = new DadosAlunoLogadoDto(string.IsNullOrEmpty(ra) ? 0 : long.Parse(ra), dispositivoId);
            return await Task.FromResult(dadosAluno);
        }
    }
}
