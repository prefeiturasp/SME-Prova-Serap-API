using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterContextosProvasPorProvaIdUseCase : IObterContextosProvasPorProvaIdUseCase
    {
        private readonly IMediator mediator;

        public ObterContextosProvasPorProvaIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
       
        public async Task<IEnumerable<ContextoProvaDto>> Executar(long id)
        {
            if (id <= 0)
                throw new NegocioException("Id da prova não informado");

            var contextosProvas = await mediator.Send(new ObterContextosProvasPorProvaIdQuery(id));

            var contextosProvasDto = new List<ContextoProvaDto>();

            foreach (var contextoProva in contextosProvas)
            {
                contextosProvasDto.Add(new ContextoProvaDto(contextoProva.Id, contextoProva.ProvaId,
                contextoProva.Titulo, contextoProva.Texto, contextoProva.Imagem,
                contextoProva.Posicionamento, contextoProva.Ordem));
            }

            return contextosProvasDto.OrderBy(a => a.Ordem);
        }
    }
}
