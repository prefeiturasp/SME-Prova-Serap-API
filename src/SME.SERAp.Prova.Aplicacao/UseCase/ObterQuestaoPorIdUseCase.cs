using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
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
            if(questao == null)
                throw new NegocioException("Questão não encontrada");

            return new QuestaoDetalheRetornoDto(questao.Id, questao.TextoBase ?? "", questao.Enunciado ?? "", questao.Ordem, (int)questao.Tipo, questao.QuantidadeAlternativas);
        }
    }
}
