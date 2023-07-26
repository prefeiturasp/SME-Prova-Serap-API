using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorProvaIdRaQueryHandler : IRequestHandler<ObterProvaAlunoPorProvaIdRaQuery, ProvaAluno>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;
        private readonly IRepositorioCache repositorioCache;

        public ObterProvaAlunoPorProvaIdRaQueryHandler(IRepositorioProvaAluno repositorioProvaAluno, IRepositorioCache repositorioCache)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
             this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        
        public async Task<ProvaAluno> Handle(ObterProvaAlunoPorProvaIdRaQuery request, CancellationToken cancellationToken)
        {
            var chaveProvaAluno = string.Format(CacheChave.AlunoProva, request.ProvaId, request.AlunoRa);
            return await repositorioCache.ObterRedisAsync(chaveProvaAluno, async () => await repositorioProvaAluno.ObterPorProvaIdRaAsync(request.ProvaId, request.AlunoRa));
        }
    }
}
