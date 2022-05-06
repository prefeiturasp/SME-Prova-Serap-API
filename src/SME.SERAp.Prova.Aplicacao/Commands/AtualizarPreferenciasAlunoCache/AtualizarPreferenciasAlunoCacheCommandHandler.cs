using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarPreferenciasAlunoCacheCommandHandler : IRequestHandler<AtualizarPreferenciasAlunoCacheCommand, bool>
    {
        private readonly IRepositorioCache repositorioCache;

        public AtualizarPreferenciasAlunoCacheCommandHandler(IRepositorioCache repositorioCache)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<bool> Handle(AtualizarPreferenciasAlunoCacheCommand request, CancellationToken cancellationToken)
        {
            await repositorioCache.SalvarRedisAsync(string.Format(CacheChave.PreferenciasAluno, request.AlunoRA), request.Dto);
            return true;
        }
    }
}
