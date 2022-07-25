using MediatR;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterQuestoesCompletaPorLegadoIdsUseCase : IObterQuestoesCompletaPorLegadoIdsUseCase
    {
        private readonly IMediator mediator;

        public ObterQuestoesCompletaPorLegadoIdsUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        }

        public async Task<string> Executar(long[] legadoIds)
        {
            var questoes = await mediator.Send(new ObterQuestaoCompletaPorLegadoIdQuery(legadoIds));
            return $"[{string.Join(",", questoes)}]";
        }
    }
}
