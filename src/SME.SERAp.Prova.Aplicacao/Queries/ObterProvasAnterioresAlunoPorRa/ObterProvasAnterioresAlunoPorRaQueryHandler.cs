using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAnterioresAlunoPorRaQueryHandler : IRequestHandler<ObterProvasAnterioresAlunoPorRaQuery, IEnumerable<ProvaAlunoAnoDto>>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;
        private readonly IRepositorioCache repositorioCache;
        public ObterProvasAnterioresAlunoPorRaQueryHandler(IRepositorioProvaAluno repositorioProvaAluno, IRepositorioCache repositorioCache)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new ArgumentNullException(nameof(repositorioProvaAluno));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<IEnumerable<ProvaAlunoAnoDto>> Handle(ObterProvasAnterioresAlunoPorRaQuery request, CancellationToken cancellationToken)
        {
            var provas = await repositorioCache.ObterRedisAsync(string.Format(CacheChave.ProvasAnteriorAluno, request.Ra), async () => await repositorioProvaAluno.ObterProvasAnterioresAlunoPorRaAsync(request.Ra), 10);
            if (provas != null && provas.Any())
            {
                return provas;
            }
            else return default;
        }
    }
}
