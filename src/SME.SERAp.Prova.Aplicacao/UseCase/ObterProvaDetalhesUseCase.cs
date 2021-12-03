using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesUseCase : IObterProvaDetalhesUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaDetalhesUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<ProvaDetalheResumidoRetornoDto> Executar(long provaId)
        {
            IEnumerable<ProvaDetalheResumidoBaseDadosDto> detalhesDaProva;

            var usuarioLogadoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));

            if (prova == null)
                throw new NegocioException("A prova infomada não foi encontrada");

            if(prova.PossuiBIB)
            {
                var caderno = await mediator.Send(new ObterCadernoAlunoPorProvaIdRaQuery(provaId, usuarioLogadoRa));
                if(string.IsNullOrEmpty(caderno))
                {
                    var aluno = await mediator.Send(new ObterAlunoSerapPorRaQuery(usuarioLogadoRa));
                    if(aluno != null)
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
                var questoesId = detalhesDaProva.Select(a => a.QuestaoId).Where(b => b > 0).Distinct().ToArray();
                var arquivosId = detalhesDaProva.Select(a => a.ArquivoId).Where(b => b > 0).Distinct().ToArray();
                var alternativasId = detalhesDaProva.Select(a => a.AlternativaId).Where(b => b > 0).Distinct().ToArray();
                var arquivosParaSomarTamanho = detalhesDaProva.Select(a => new { TamanhoInBytes = a.ArquivoTamanho, Id = a.ArquivoId }).Distinct();
                var tamanhoTotalArquivos = arquivosParaSomarTamanho.Sum(a => a.TamanhoInBytes);

                var contextoProva = await mediator.Send(new ObterContextosProvasPorProvaIdQuery(provaId));
                long[] contextoProvaIds = System.Array.Empty<long>();
                if (contextoProva.Any())
                    contextoProvaIds = contextoProva.Select(a => a.Id).Distinct().ToArray();

                return new ProvaDetalheResumidoRetornoDto(provaId, questoesId, arquivosId, alternativasId, tamanhoTotalArquivos, contextoProvaIds);

            }
            else return default;



        }
    }
}
