using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoPorIdUseCase : IObterArquivoPorIdUseCase
    {
        private readonly IMediator mediator;

        public ObterArquivoPorIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ArquivoRetornoDto> Executar(long id)
        {
            var arquivo = await mediator.Send(new ObterArquivoPorIdQuery(id));

            return new ArquivoRetornoDto(arquivo.Id, arquivo.Caminho);
        }

    }
}
