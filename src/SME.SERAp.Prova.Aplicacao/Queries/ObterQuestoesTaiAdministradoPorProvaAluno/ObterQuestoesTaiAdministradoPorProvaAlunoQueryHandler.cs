using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestoesTaiAdministradoPorProvaAlunoQueryHandler : IRequestHandler<ObterQuestoesTaiAdministradoPorProvaAlunoQuery, IEnumerable<QuestaoTaiDto>>
    {
        private readonly IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai;
        private readonly IRepositorioCache repositorioCache;

        public ObterQuestoesTaiAdministradoPorProvaAlunoQueryHandler(IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai, IRepositorioCache repositorioCache)
        {
            this.repositorioQuestaoAlunoTai = repositorioQuestaoAlunoTai ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoTai));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<IEnumerable<QuestaoTaiDto>> Handle(ObterQuestoesTaiAdministradoPorProvaAlunoQuery request, CancellationToken cancellationToken)
        {
            var nomeChave = CacheChave.ObterChave(CacheChave.QuestaoAdministradoTaiAluno, request.AlunoId, request.ProvaId);
            if (!request.UtilizarCache)
            {
                var resultado = await repositorioQuestaoAlunoTai.ObterQuestoesTaiPorProvaAlunoAsync(request.ProvaId, request.AlunoId);
                await repositorioCache.SalvarRedisAsync(nomeChave, resultado);
                return resultado;
            }
            
            return await repositorioCache.ObterRedisAsync(nomeChave, async() => await repositorioQuestaoAlunoTai.ObterQuestoesTaiPorProvaAlunoAsync(request.ProvaId, request.AlunoId));            
        }
    }
}