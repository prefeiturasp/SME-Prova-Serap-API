using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTurmasAlunoPorRaQueryHandler : IRequestHandler<ObterTurmasAlunoPorRaQuery, IEnumerable<Turma>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioTurma repositorioTurma;

        public ObterTurmasAlunoPorRaQueryHandler(IRepositorioCache repositorioCache, IRepositorioTurma repositorioTurma)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.repositorioTurma = repositorioTurma ?? throw new System.ArgumentNullException(nameof(repositorioTurma));
        }

        public async Task<IEnumerable<Turma>> Handle(ObterTurmasAlunoPorRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync(string.Format(CacheChave.AlunoTurma, request.AlunoRa), () => repositorioTurma.ObterTurmasAlunoPorRaAsync(request.AlunoRa));
        }
    }
}
