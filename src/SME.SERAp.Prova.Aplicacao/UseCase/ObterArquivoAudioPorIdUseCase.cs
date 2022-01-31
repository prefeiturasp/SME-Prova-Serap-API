using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoAudioPorIdUseCase : IObterArquivoAudioPorIdUseCase
    {
        private readonly IMediator mediator;

        public ObterArquivoAudioPorIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ArquivoRetornoDto> Executar(long id)
        {
            var arquivoAudio = await mediator.Send(new ObterArquivoAudioPorIdQuery(id));

            if (arquivoAudio == null)
                throw new NegocioException("O Arquivo não foi encontrado");

            return arquivoAudio;
        }
    }
}
