using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoPorIdUseCase : IObterQuestaoPorIdUseCase
    {
        private readonly IMediator mediator;

        public ObterQuestaoPorIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<QuestaoDetalheRetornoDto> Executar(long id)
        {
            var questao = await mediator.Send(new ObterQuestaoPorIdQuery(id));

            return new QuestaoDetalheRetornoDto(questao.Id, questao.Enunciado, questao.Pergunta, questao.Ordem);
        }
    }
}
