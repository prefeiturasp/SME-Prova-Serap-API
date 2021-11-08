using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterContextoProvaPorIdUseCase : IObterContextoProvaPorIdUseCase
    {
        private readonly IMediator mediator;

        public ObterContextoProvaPorIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ContextoProvaDto> Executar(long id)
        {
            if (id <= 0)
                throw new NegocioException("Id do contexto da prova não informado");

            var contextoProva = await mediator.Send(new ObterContextoProvaPorIdQuery(id));

            return new ContextoProvaDto(contextoProva.Id, contextoProva.ProvaId, 
                contextoProva.Titulo, contextoProva.Texto, contextoProva.Imagem, 
                contextoProva.Posicionamento, contextoProva.Ordem);
        }
    }
}
