using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoPorIdLegadoUseCase : IObterArquivoPorIdLegadoUseCase
    {
        private readonly IMediator mediator;

        public ObterArquivoPorIdLegadoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ArquivoRetornoDto> Executar(long id)
        {
            var arquivo = await mediator.Send(new ObterArquivoPorIdLegadoQuery(id));

            var questaoArquivo = await mediator.Send(new ObterQuestaoArquivoPorArquivoIdQuery(arquivo.Id));

            return new ArquivoRetornoDto(arquivo.LegadoId, arquivo.Caminho, questaoArquivo.QuestaoId);
        }

    }
}
