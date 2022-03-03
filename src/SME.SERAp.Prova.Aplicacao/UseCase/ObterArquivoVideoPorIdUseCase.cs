using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoVideoPorIdUseCase : IObterArquivoVideoPorIdUseCase
    {

        private readonly IMediator mediator;

        public ObterArquivoVideoPorIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ArquivoVideoResponseDto> Executar(long idVideo)
        {
            string caminhoVideoConvertido = string.Empty;
            string caminhoVideoThumbinail = string.Empty;

            var questaoVideo = await mediator.Send(new ObterQuestaoVideoPorIdQuery(idVideo));
            if (questaoVideo == null)
                throw new NegocioException("O vídeo não foi encontrado");

            var arquivoVideo = await mediator.Send(new ObterArquivoPorIdQuery(questaoVideo.ArquivoVideoId));
            if (arquivoVideo == null)
                throw new NegocioException("O arquivo de vídeo não foi encontrado");

            if (questaoVideo.ArquivoVideoConvertidoId != null)
                caminhoVideoConvertido = await ObterCaminhoArquivoPorId((long)questaoVideo.ArquivoVideoConvertidoId);

            if (questaoVideo.ArquivoThumbnailId != null)
                caminhoVideoThumbinail = await ObterCaminhoArquivoPorId((long)questaoVideo.ArquivoThumbnailId);

            return new ArquivoVideoResponseDto(questaoVideo.Id, arquivoVideo.Caminho, caminhoVideoConvertido, caminhoVideoThumbinail, questaoVideo.QuestaoId);
        }

        private async Task<string> ObterCaminhoArquivoPorId(long id)
        {
            var arquivo = await mediator.Send(new ObterArquivoPorIdQuery(id));
            if (arquivo != null)
                return arquivo.Caminho;

            return string.Empty;
        }
    }
}
