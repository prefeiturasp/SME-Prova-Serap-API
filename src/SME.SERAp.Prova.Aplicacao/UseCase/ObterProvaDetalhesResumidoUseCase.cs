using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
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
            var usuarioLogadoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            if (usuarioLogadoRa == 0)
                throw new NegocioException($"Usuário infomado {usuarioLogadoRa} não foi encontrado");

            var prova = await mediator.Send(new ObterProvaPorIdQuery(provaId));
            if (prova == null)
                throw new NegocioException($"A prova infomada {provaId} não foi encontrada");
            
            if (prova.FormatoTai)
                throw new NegocioException($"Prova TAI {provaId} não possui resumo detalhado. Usuário: {usuarioLogadoRa}.");

            var questoesResumo = await mediator.Send(new ObterQuestaoResumoPorProvaIdQuery(provaId));            
            if(questoesResumo == null || !questoesResumo.Any())
                throw new NegocioException($"Nenhuma questão foi encontrada para a prova {provaId}");

            if (prova.PossuiBIB)
            {
                var caderno = await mediator.Send(new ObterCadernoAlunoPorProvaIdRaQuery(provaId, usuarioLogadoRa));
                if (string.IsNullOrEmpty(caderno))
                    throw new NegocioException($"Usuário informado {usuarioLogadoRa} não possui caderno para a prova {provaId}");

                questoesResumo = questoesResumo.Where(t => t.Caderno == caderno);
            }

            var questoesIds = questoesResumo.Select(t => t.QuestaoId).ToArray();

            long[] contextosIds = Array.Empty<long>();
            var contextosResumo = await mediator.Send(new ObterContextoResumoPorProvaIdQuery(provaId));
            if(contextosResumo != null && contextosResumo.Any())
                contextosIds = contextosResumo.Select(t => t.ContextoProvaId).ToArray();

            return new ProvaDetalheResumidoRetornoDto(provaId, questoesIds, contextosIds);
        }
    }
}
