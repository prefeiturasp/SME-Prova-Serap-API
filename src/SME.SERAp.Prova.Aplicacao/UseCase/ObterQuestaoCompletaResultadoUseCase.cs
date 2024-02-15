using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoCompletaResultadoUseCase : IObterQuestaoCompletaResultadoUseCase
    {

        private readonly IMediator mediator;

        public ObterQuestaoCompletaResultadoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<QuestaoCompletaResultadoDto> Executar(long provaId, long questaoLegadoId)
        {
            var ra = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var questaoCompletaResultado = await mediator.Send(new ObterQuestaoCompletaResultadoQuery(ra, provaId, questaoLegadoId));

            if (questaoCompletaResultado == null) return default;

            questaoCompletaResultado.Questao = await ObterJsonQuestaoCompleta(questaoLegadoId);

            return questaoCompletaResultado;
        }

        private async Task<QuestaoCompletaDto> ObterJsonQuestaoCompleta(long questaoLegadoId)
        {
            var questoes = await mediator.Send(new ObterQuestaoCompletaPorLegadoIdQuery(new long[] { questaoLegadoId }));
            if (questoes == null || !questoes.Any()) return null;
            return JsonSerializer.Deserialize<QuestaoCompletaDto>(questoes.FirstOrDefault());
        }
    }
}
