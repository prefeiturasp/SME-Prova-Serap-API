using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
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
            string chaveProvaAluno = request.ProvaId.ToString() + request.AlunoRa.ToString();
            return await repositorioCache.ObterRedisAsync(chaveProvaAluno, async () => await repositorioProvaAluno.ObterPorProvaIdRaAsync(request.ProvaId, request.AlunoRa));
        }
    }
}
