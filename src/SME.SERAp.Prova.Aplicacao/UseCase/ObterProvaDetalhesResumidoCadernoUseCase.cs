using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesResumidoCadernoUseCase : IObterProvaDetalhesResumidoCadernoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaDetalhesResumidoCadernoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ProvaDetalheResumidoCadernoRetornoDto> Executar(long provaId, string caderno)
        {
            var usuarioLogadoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            if (usuarioLogadoRa == 0)
                throw new NegocioException($"Usuário infomado {usuarioLogadoRa} não foi encontrado");

            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));
            if (prova == null)
                throw new NegocioException($"A prova infomada {provaId} não foi encontrada");

            var questoesResumo = await mediator.Send(new ObterQuestaoResumoPorProvaIdQuery(provaId, usuarioLogadoRa));
            if (questoesResumo == null || !questoesResumo.Any())
                throw new NegocioException($"Nenhuma questão foi encontrada para a prova {provaId}");

            if (prova.PossuiBIB)
            {
                questoesResumo = questoesResumo.Where(t => t.Caderno == caderno);
            }

            var questoesIds = questoesResumo.Select(t => new QuestaoOrdemDto(
                t.QuestaoId,
                t.QuestaoLegadoId,
                t.Alternativas.Select(x => new AlternativaOrdemDto(x.AlternativaId, x.AlternativaLegadoId, x.Ordem)).OrderBy(t => t.Ordem).ToArray(),
                t.Ordem)
            ).OrderBy(t => t.Ordem).ToArray();

            long[] contextosIds = Array.Empty<long>();
            var contextosResumo = await mediator.Send(new ObterContextoResumoPorProvaIdQuery(provaId));
            if (contextosResumo != null && contextosResumo.Any())
                contextosIds = contextosResumo.Select(t => t.ContextoProvaId).ToArray();

            return new ProvaDetalheResumidoCadernoRetornoDto(provaId, questoesIds, contextosIds);
        }
    }
}
