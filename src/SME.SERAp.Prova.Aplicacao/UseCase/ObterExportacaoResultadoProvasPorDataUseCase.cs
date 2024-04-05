using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoProvasPorDataUseCase : IObterExportacaoResultadoProvasPorDataUseCase
    {
        private readonly IMediator mediator;

        public ObterExportacaoResultadoProvasPorDataUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<ExportacaoRetornoSerapDto>> Executar(FiltroExportacaoResultadoDto filtro)
        {
            return  await mediator.Send(new ObterExportacaoResultadoProvasPorDataPaginadaQuery(filtro));
        }
    }
}
