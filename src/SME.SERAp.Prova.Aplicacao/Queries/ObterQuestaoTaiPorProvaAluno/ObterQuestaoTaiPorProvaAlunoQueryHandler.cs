using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoTaiPorProvaAlunoQueryHandler : IRequestHandler<ObterQuestaoTaiPorProvaAlunoQuery, IEnumerable<QuestaoTaiDto>>
    {
        private readonly IRepositorioQuestao repositorioQuestao;
        private readonly IRepositorioCache repositorioCache;

        public ObterQuestaoTaiPorProvaAlunoQueryHandler(IRepositorioQuestao repositorioQuestao, IRepositorioCache repositorioCache)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<IEnumerable<QuestaoTaiDto>> Handle(ObterQuestaoTaiPorProvaAlunoQuery request, CancellationToken cancellationToken)
        {
            var nomeChave = CacheChave.ObterChave(CacheChave.QuestaoAmostraTaiAluno, request.AlunoRa, request.ProvaId);
            return await repositorioCache.ObterRedisAsync(nomeChave, () => repositorioQuestao.ObterQuestaoTaiPorProvaAlunoRa(request.ProvaId, request.AlunoRa));
        }
    }
}
