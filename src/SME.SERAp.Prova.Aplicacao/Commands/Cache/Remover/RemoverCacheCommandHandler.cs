using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class RemoverCacheCommandHandler : IRequestHandler<RemoverCacheCommand, bool>
    {
        private readonly IRepositorioCache repositorioCache;

        public RemoverCacheCommandHandler(IRepositorioCache repositorioCache)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<bool> Handle(RemoverCacheCommand request, CancellationToken cancellationToken)
        {
            await repositorioCache.RemoverRedisAsync(request.NomeChave);
            return true;
        }
    }
}
