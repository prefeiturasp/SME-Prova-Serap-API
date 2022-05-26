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
    public class ObterQuestaoCompletaPorIdQueryHandler : IRequestHandler<ObterQuestaoCompletaPorIdQuery, IEnumerable<string>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoCompletaPorIdQueryHandler(IRepositorioCache repositorioCache, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<IEnumerable<string>> Handle(ObterQuestaoCompletaPorIdQuery request, CancellationToken cancellationToken)
        {
            var retorno = new List<string>();

            string nomeChave, json;
            var buscarNoBanco = new List<long>();

            foreach(var questaoId in request.QuestoesIds)
            {
                nomeChave = string.Format(CacheChave.QuestaoCompleta, questaoId);
                json = await repositorioCache.ObterRedisToJsonAsync(nomeChave);

                if(string.IsNullOrEmpty(json))
                    buscarNoBanco.Add(questaoId);
                else
                    retorno.Add(json);
            }

            if(buscarNoBanco.Any())
            {
                var questoes = await repositorioQuestao.ObterQuestaoCompletaPorIdsAsync(buscarNoBanco.ToArray());
                foreach(var questao in questoes)
                {
                    nomeChave = string.Format(CacheChave.QuestaoCompleta, questao.Id);
                    retorno.Add(questao.Json);
                    await repositorioCache.SalvarRedisToJsonAsync(nomeChave, questao.Json);
                }
            }

            return retorno;
        }
    }
}
