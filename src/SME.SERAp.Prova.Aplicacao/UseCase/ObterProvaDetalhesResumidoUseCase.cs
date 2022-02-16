using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesResumidoUseCase : IObterProvaDetalhesResumidoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaDetalhesResumidoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ProvaDetalheResumidoRetornoDto> Executar(long provaId)
        {
            IEnumerable<ProvaDetalheResumidoBaseDadosDto> detalhesDaProva;

            var usuarioLogadoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));

            if (prova == null)
                throw new NegocioException("A prova infomada não foi encontrada");

            if (prova.PossuiBIB)
            {
                var caderno = await mediator.Send(new ObterCadernoAlunoPorProvaIdRaQuery(provaId, usuarioLogadoRa));
                if (string.IsNullOrEmpty(caderno))
                {
                    var aluno = await mediator.Send(new ObterAlunoSerapPorRaQuery(usuarioLogadoRa));
                    if (aluno != null)
                    {
                        var totalCadernos = prova.TotalCadernos;
                        Random sortear = new Random();
                        var cadernoSorteado = sortear.Next(1, totalCadernos).ToString();
                        await mediator.Send(new IncluirCadernoAlunoCommand(aluno.Id, provaId, cadernoSorteado));
                    }
                }
                detalhesDaProva = await mediator.Send(new ObterProvaDetalhesResumidoBIBQuery(provaId, usuarioLogadoRa));
            }

            else
                detalhesDaProva = await mediator.Send(new ObterProvaDetalhesResumidoQuery(provaId));

            if (detalhesDaProva.Any())
            {
                List<long> arquivosId = new();
                var questoesId = detalhesDaProva.Select(a => a.QuestaoId).Where(b => b > 0).Distinct().ToArray();
                var alternativasId = detalhesDaProva.Select(a => a.AlternativaId).Where(b => b > 0).Distinct().ToArray();

                arquivosId.AddRange(detalhesDaProva.Select(a => a.QuestaoArquivoId).Where(b => b > 0).Distinct().ToArray());
                arquivosId.AddRange(detalhesDaProva.Select(a => a.AlternativaArquivoId).Where(b => b > 0).Distinct().ToArray());


                var questoesArquivoSomarTamanho = detalhesDaProva.Select(a => new { TamanhoInBytes = a.QuestaoArquivoTamanho, Id = a.QuestaoArquivoId }).Distinct();
                var alternativasArquivoSomarTamanho = detalhesDaProva.Select(a => new { TamanhoInBytes = a.QuestaoArquivoTamanho, Id = a.QuestaoArquivoId }).Distinct();

                var tamanhoTotalArquivos = questoesArquivoSomarTamanho.Sum(a => a.TamanhoInBytes) + alternativasArquivoSomarTamanho.Sum(a => a.TamanhoInBytes);

                var contextoProva = await mediator.Send(new ObterContextosProvasPorProvaIdQuery(provaId));
                long[] contextoProvaIds = Array.Empty<long>();
                if (contextoProva.Any())
                    contextoProvaIds = contextoProva.Select(a => a.Id).Distinct().ToArray();

                long[] audiosId = Array.Empty<long>();
                var provaComAudio = await mediator.Send(new ObterProvasComAudioPorIdsQuery(new long[] { provaId }));
                if (provaComAudio.Any(a => a == provaId))
                    audiosId = await ObterAudioIds(questoesId);

                List<QuestaoVideoRetornoDto> videos = new();
                var provaComVideo = await mediator.Send(new ObterProvasComVideoPorIdsQuery(new long[] { provaId }));
                if (provaComVideo.Any(a => a == provaId))
                    videos = await ObterVideos(questoesId);

                return new ProvaDetalheResumidoRetornoDto(provaId, questoesId, arquivosId.ToArray(), alternativasId, tamanhoTotalArquivos, contextoProvaIds, audiosId, videos);

            }
            else return default;
        }

        public async Task<long[]> ObterAudioIds(long[] questoesId)
        {
            List<long> audiosId = new();
            foreach (long questaoId in questoesId)
            {
                var audiosQuestao = await mediator.Send(new ObterArquivosAudiosIdsPorQuestaoIdQuery(questaoId));
                if (audiosQuestao != null && audiosQuestao.Any())
                    audiosId.AddRange(audiosQuestao.ToList());
            }
            return audiosId.ToArray();
        }

        private async Task<List<QuestaoVideoRetornoDto>> ObterVideos(long[] questoesId)
        {
            List<QuestaoVideoRetornoDto> videosRetorno = new();
            foreach (long questaoId in questoesId)
            {
                var videos = await mediator.Send(new ObterVideosPorQuestaoIdQuery(questaoId));
                if(videos != null && videos.Any())
                {
                    videosRetorno.AddRange(videos.Select(v => new QuestaoVideoRetornoDto(v.ArquivoVideoId, v.ArquivoThumbnailId, v.ArquivoVideoConvertidoId)));
                }
            }
            return videosRetorno;
        }
    }
}
