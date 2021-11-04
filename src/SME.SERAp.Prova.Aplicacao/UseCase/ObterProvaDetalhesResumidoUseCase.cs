using MediatR;
using SME.SERAp.Prova.Infra;
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
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<ProvaDetalheResumidoRetornoDto> Executar(long provaId)
        {
            IEnumerable<ProvaDetalheResumidoBaseDadosDto> detalhesDaProva;

            var usuarioLogadoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));

            if(prova.PossuiBIB)
                detalhesDaProva = await mediator.Send(new ObterProvaDetalhesResumidoBIBQuery(provaId, usuarioLogadoRa));
            else
                detalhesDaProva = await mediator.Send(new ObterProvaDetalhesResumidoQuery(provaId));

            if (detalhesDaProva.Any())
            {
                var questoesId = detalhesDaProva.Select(a => a.QuestaoId).Distinct().ToArray();
                var arquivosId = detalhesDaProva.Select(a => a.ArquivoId).Where(b => b > 0).Distinct().ToArray();
                var alternativasId = detalhesDaProva.Select(a => a.AlternativaId).Distinct().ToArray();
                var arquivosParaSomarTamanho = detalhesDaProva.Select(a => new { TamanhoInBytes = a.ArquivoTamanho, Id = a.ArquivoId }).Distinct();
                var tamanhoTotalArquivos = arquivosParaSomarTamanho.Sum(a => a.TamanhoInBytes);

                return new ProvaDetalheResumidoRetornoDto(provaId, questoesId, arquivosId, alternativasId, tamanhoTotalArquivos);

            }
            else return default;



        }
    }
}
