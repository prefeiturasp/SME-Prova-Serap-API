using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCadernoAlunoPorProvaIdRaQueryHandler : IRequestHandler<ObterCadernoAlunoPorProvaIdRaQuery, string>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioProva repositorioProva;

        public ObterCadernoAlunoPorProvaIdRaQueryHandler(IRepositorioCache repositorioCache, IRepositorioProva repositorioProva)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }

        public async Task<string> Handle(ObterCadernoAlunoPorProvaIdRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync(string.Format(CacheChave.AlunoCadernoProva, request.ProvaId, request.AlunoRA), () => repositorioProva.ObterCadernoAlunoPorProvaIdRa(request.ProvaId, request.AlunoRA));
        }
    }
}
