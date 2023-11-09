using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTelasBoasVindasUseCase : IObterTelasBoasVindasUseCase
    {
        private readonly IMediator mediator;

        public ObterTelasBoasVindasUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<IEnumerable<TelaBoasVindasDto>> Executar()
        {
            var telasBoasVindas = await mediator.Send(new ObterConfiguracaoTelasBoasVindasQuery());
            if (!telasBoasVindas.Any())
                throw new NegocioException("Nenhuma tela de boas vindas foi encontrada");

            var telasBoasVindasRetornar = new List<TelaBoasVindasDto>();

            foreach (var telaBoasVindas in telasBoasVindas)
            {
                telasBoasVindasRetornar.Add(new TelaBoasVindasDto(telaBoasVindas.Id, 
                    telaBoasVindas.Titulo, telaBoasVindas.Descricao, telaBoasVindas.Imagem, 
                    telaBoasVindas.Ordem));
            }

            return telasBoasVindasRetornar.OrderBy(a => a.Ordem);
        }
    }
}
