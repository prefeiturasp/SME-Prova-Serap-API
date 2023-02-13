using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlternativaAlunoRespostaQueryHandler : IRequestHandler<ObterAlternativaAlunoRespostaQuery, IEnumerable<QuestaoAlternativaAlunoRespostaDto>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public ObterAlternativaAlunoRespostaQueryHandler(IRepositorioCache repositorioCache, IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoResposta));
        }

        public async Task<IEnumerable<QuestaoAlternativaAlunoRespostaDto>> Handle(ObterAlternativaAlunoRespostaQuery request, CancellationToken cancellationToken)
        {
            var nomeChave = CacheChave.ObterChave(CacheChave.RespostaAmostraTaiAluno, request.AlunoRa, request.ProvaId);
            return await repositorioCache.ObterRedisAsync(nomeChave, () => repositorioQuestaoAlunoResposta.QuestaoAlternativaAlunoRespostaTaiAsync(request.AlunoRa, request.ProvaId));
        }
    }
}
