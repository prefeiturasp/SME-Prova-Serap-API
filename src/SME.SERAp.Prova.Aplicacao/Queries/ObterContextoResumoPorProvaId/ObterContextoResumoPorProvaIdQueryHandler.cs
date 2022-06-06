using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterContextoResumoPorProvaIdQueryHandler : IRequestHandler<ObterContextoResumoPorProvaIdQuery, IEnumerable<ContextoResumoProvaDto>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioContextoProva repositorioContextoProva;

        public ObterContextoResumoPorProvaIdQueryHandler(IRepositorioCache repositorioCache, IRepositorioContextoProva repositorioContextoProva)
        {
            this.repositorioCache = repositorioCache;
            this.repositorioContextoProva = repositorioContextoProva;
        }

        public async Task<IEnumerable<ContextoResumoProvaDto>> Handle(ObterContextoResumoPorProvaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync(string.Format(CacheChave.ContextoProvaResumo, request.ProvaId), () => repositorioContextoProva.ObterContextoProvaResumoPorProvaIdAsync(request.ProvaId));
        }
    }
}
