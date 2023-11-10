using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SME.SERAp.Prova.Infra.Exceptions;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaPorLegadoIdQueryHandler : IRequestHandler<ObterQuestaoCompletaPorLegadoIdQuery, IEnumerable<string>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoCompletaPorLegadoIdQueryHandler(IRepositorioCache repositorioCache, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<IEnumerable<string>> Handle(ObterQuestaoCompletaPorLegadoIdQuery request, CancellationToken cancellationToken)
        {
            var retorno = new List<string>();

            string nomeChave;
            var buscarNoBanco = new List<long>();

            foreach(var questaoId in request.LegadoIds)
            {
                nomeChave = string.Format(CacheChave.QuestaoCompletaLegado, questaoId);
                var json = await repositorioCache.ObterRedisToJsonAsync(nomeChave);

                if(string.IsNullOrEmpty(json))
                    buscarNoBanco.Add(questaoId);
                else
                    retorno.Add(json);
            }

            if (!buscarNoBanco.Any()) 
                return retorno;

            foreach (var legadoId in buscarNoBanco)
            {
                var questao = await repositorioQuestao.ObterQuestaoCompletaPorLegadoIdAsync(legadoId);

                if (questao == null)
                    throw new NegocioException($"Questao completa legado Id {legadoId} não localizada.");

                nomeChave = string.Format(CacheChave.QuestaoCompletaLegado, questao.Id);
                retorno.Add(questao.Json);

                await repositorioCache.SalvarRedisToJsonAsync(nomeChave, questao.Json);                
            }

            return retorno;
        }
    }
}
