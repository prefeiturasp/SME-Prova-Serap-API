using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorProvaIdsRaQueryHandler : IRequestHandler<ObterProvaAlunoPorProvaIdsRaQuery, IEnumerable<ProvaAluno>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioProvaAluno repositorioProvaAluno;

        public ObterProvaAlunoPorProvaIdsRaQueryHandler(IRepositorioCache repositorioCache, IRepositorioProvaAluno repositorioProvaAluno)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
        }
        public async Task<IEnumerable<ProvaAluno>> Handle(ObterProvaAlunoPorProvaIdsRaQuery request, CancellationToken cancellationToken)
        {
            var lista = new List<ProvaAluno>();

            foreach (var provaId in request.ProvaIds)
            {
                var chaveProvaAluno = string.Format(CacheChave.AlunoProva, provaId, request.AlunoRa);
                var provaAluno = await repositorioCache.ObterRedisAsync(chaveProvaAluno, () => repositorioProvaAluno.ObterPorProvaIdRaAsync(provaId , request.AlunoRa));

                if (provaAluno != null)
                    lista.Add(provaAluno);
            }

            return lista;
        }
    }
}
