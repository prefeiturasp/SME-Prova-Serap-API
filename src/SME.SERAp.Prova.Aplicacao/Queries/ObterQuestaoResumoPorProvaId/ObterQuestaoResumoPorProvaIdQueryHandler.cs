using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoResumoPorProvaIdQueryHandler : IRequestHandler<ObterQuestaoResumoPorProvaIdQuery, IEnumerable<QuestaoResumoProvaDto>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoResumoPorProvaIdQueryHandler(IRepositorioCache repositorioCache, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<IEnumerable<QuestaoResumoProvaDto>> Handle(ObterQuestaoResumoPorProvaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync(string.Format(CacheChave.QuestaoProvaResumo, request.ProvaId, request.AlunoId), () => repositorioQuestao.ObterQuestaoResumoPorProvaIdAsync(request.ProvaId, request.AlunoId));
        }
    }
}
