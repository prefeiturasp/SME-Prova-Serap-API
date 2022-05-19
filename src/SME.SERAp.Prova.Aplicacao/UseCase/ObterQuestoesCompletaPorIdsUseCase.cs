using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestoesCompletaPorIdsUseCase : IObterQuestoesCompletaPorIdsUseCase
    {
        private readonly IMediator mediator;
        
        public ObterQuestoesCompletaPorIdsUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<QuestaoCompletaDto>> Executar(long[] ids)
        {
            var retorno = new List<QuestaoCompletaDto>();
            foreach(var id in ids)
            {
                var questao = await mediator.Send(new ObterQuestaoCompletaPorIdQuery(id));
                retorno.Add(questao);
            }
            
            return retorno;
        }
    }
}
