using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterDataUltimaSincronizacaoProvasUseCase : IObterDataUltimaSincronizacaoProvasUseCase
    {
        private readonly IMediator mediator;

        public ObterDataUltimaSincronizacaoProvasUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<long> Executar()
        {
            var ultimaExecucao = await mediator.Send(new ObterUltimaExecucaoControleTipoPorTipoQuery(ExecucaoControleTipo.ProvaLegadoSincronizacao));
            if (ultimaExecucao == null) throw new NegocioException("Não foi possível obter a data da última sincronização de provas.");
            return ultimaExecucao.UltimaExecucao.Ticks;
        }
    }
}
