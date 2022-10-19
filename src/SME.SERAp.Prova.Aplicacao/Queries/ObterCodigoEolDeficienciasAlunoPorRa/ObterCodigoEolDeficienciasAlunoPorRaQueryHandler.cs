using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCodigoEolDeficienciasAlunoPorRaQueryHandler : IRequestHandler<ObterCodigoEolDeficienciasAlunoPorRaQuery, List<int>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioTipoDeficiencia repositorioTipoDeficiencia;

        public ObterCodigoEolDeficienciasAlunoPorRaQueryHandler(IRepositorioCache repositorioCache, IRepositorioTipoDeficiencia repositorioTipoDeficiencia)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.repositorioTipoDeficiencia = repositorioTipoDeficiencia ?? throw new System.ArgumentNullException(nameof(repositorioTipoDeficiencia));
        }

        public async Task<List<int>> Handle(ObterCodigoEolDeficienciasAlunoPorRaQuery request, CancellationToken cancellationToken)
        {
            var deficienciasAluno = await repositorioCache.ObterRedisAsync(string.Format(CacheChave.AlunoDeficiencia, request.AlunoRa),() => repositorioTipoDeficiencia.ObterPorAlunoRa(request.AlunoRa));
            return deficienciasAluno.Select(d => d.CodigoEol).ToList();
        }
    }
}
