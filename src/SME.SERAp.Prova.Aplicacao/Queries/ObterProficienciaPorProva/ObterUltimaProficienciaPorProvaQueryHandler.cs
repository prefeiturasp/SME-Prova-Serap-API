using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaProficienciaPorProvaQueryHandler : IRequestHandler<ObterUltimaProficienciaPorProvaQuery, decimal>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioAlunoProvaProficiencia repositorioAlunoProvaProficiencia;

        public ObterUltimaProficienciaPorProvaQueryHandler(IRepositorioCache repositorioCache, IRepositorioAlunoProvaProficiencia repositorioAlunoProvaProficiencia)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioAlunoProvaProficiencia = repositorioAlunoProvaProficiencia ?? throw new ArgumentNullException(nameof(repositorioAlunoProvaProficiencia));
        }

        public async Task<decimal> Handle(ObterUltimaProficienciaPorProvaQuery request, CancellationToken cancellationToken)
        {
            var chaveCache = CacheChave.ObterChave(CacheChave.UltimaProficienciaProva, request.AlunoRa, request.ProvaId);
            return await repositorioCache.ObterRedisAsync(chaveCache, () => repositorioAlunoProvaProficiencia.ObterUltimaProficienciaAlunoPorProvaIdAsync(request.ProvaId, request.AlunoRa));
        }
    }
}
