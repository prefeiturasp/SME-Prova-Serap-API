using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoPorIdQueryHandler : IRequestHandler<ObterQuestaoPorIdQuery, Questao>
    {
        private readonly IRepositorioQuestao repositorioQuestao;
        private readonly IRepositorioCache repositorioCache;

        public ObterQuestaoPorIdQueryHandler(IRepositorioQuestao repositorioQuestao, IRepositorioCache repositorioCache)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new System.ArgumentNullException(nameof(repositorioQuestao));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<Questao> Handle(ObterQuestaoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync($"q-{request.Id}", async () => await repositorioQuestao.ObterPorIdAsync(request.Id));
        }
    }
}
