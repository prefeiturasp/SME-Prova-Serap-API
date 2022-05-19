using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaPorIdQueryHandler : IRequestHandler<ObterQuestaoCompletaPorIdQuery, QuestaoCompletaDto>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoCompletaPorIdQueryHandler(IRepositorioCache repositorioCache, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<QuestaoCompletaDto> Handle(ObterQuestaoCompletaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync(string.Format(CacheChave.QuestaoCompleta, request.QuestaoId), () => repositorioQuestao.ObterQuestaoCompletaPorIdAsync(request.QuestaoId));
        }
    }
}
