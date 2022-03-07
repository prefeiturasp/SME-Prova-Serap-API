using MediatR;
using SME.SERAp.Prova.Aplicacao.Queries;
using SME.SERAp.Prova.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterQuestaoDetalhesResumidoAreaAdministrativoUseCase : IObterQuestaoDetalhesResumidoAreaAdministrativoUseCase
    {
        private readonly IMediator mediator;

        public ObterQuestaoDetalhesResumidoAreaAdministrativoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<QuestaoDetalheResumoRetornoDto> Executar(long provaId, long questaoId)
        {
            var detalhes = await mediator.Send(new ObterQuestaoDetalhesResumidoAreaAdministrativoQuery(provaId, questaoId));

            if (detalhes.Any())
            {
                List<long> arquivosId = new();
                List<long> alternativasId = new();
                List<long> audiosId = new();
                List<long> videosId = new();

                foreach (var detalhe in detalhes)
                {
                    if (detalhe.QuestaoArquivoId > 0) arquivosId.Add(detalhe.QuestaoArquivoId);
                    if (detalhe.AlternativaArquivoId > 0) arquivosId.Add(detalhe.AlternativaArquivoId);
                    if (detalhe.AlternativaId > 0) alternativasId.Add(detalhe.AlternativaId);
                    if (detalhe.AudioId > 0) audiosId.Add(detalhe.AudioId);
                    if (detalhe.VideoId > 0) videosId.Add(detalhe.VideoId);
                }

                return new QuestaoDetalheResumoRetornoDto(
                    provaId,
                    questaoId,
                    arquivosId.Distinct().ToArray(),
                    alternativasId.Distinct().ToArray(),
                    audiosId.Distinct().ToArray(),
                    videosId.Distinct().ToArray()
                );
            }

            return default;
        }
    }
}
