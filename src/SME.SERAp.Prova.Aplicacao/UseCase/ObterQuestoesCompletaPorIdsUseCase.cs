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

        public async Task<string> Executar(long[] ids)
        {
            var questoes = await mediator.Send(new ObterQuestaoCompletaPorIdQuery(ids));
            return $"[{string.Join(",", questoes)}]" ;
        }
    }
}
