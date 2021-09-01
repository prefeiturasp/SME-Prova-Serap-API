using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlternativaPorIdUseCase : IObterAlternativaPorIdUseCase
    {
        private readonly IMediator mediator;

        public ObterAlternativaPorIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<AlternativaDetalheRetornoDto> Executar(long id)
        {
            var alternativa = await mediator.Send(new ObterAlternativaPorIdQuery(id));

            return new AlternativaDetalheRetornoDto(alternativa.Id, alternativa.Descricao,
                alternativa.Ordem, alternativa.Numeracao, alternativa.QuestaoId);
        }
    }
}
