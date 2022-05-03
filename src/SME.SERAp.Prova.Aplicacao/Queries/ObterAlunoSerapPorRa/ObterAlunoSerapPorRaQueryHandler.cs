using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoSerapPorRaQueryHandler : IRequestHandler<ObterAlunoSerapPorRaQuery, Aluno>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioAluno repositorioAluno;

        public ObterAlunoSerapPorRaQueryHandler(IRepositorioCache repositorioCache, IRepositorioAluno repositorioAluno)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }

        public async Task<Aluno> Handle(ObterAlunoSerapPorRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync(string.Format(CacheChave.Aluno, request.AlunoRA), () => repositorioAluno.ObterPorRA(request.AlunoRA));
        }
    }
}
