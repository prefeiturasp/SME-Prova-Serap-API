using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
   public class ObterExportacaoResultadoProvasPorDataQueryHandler : IRequestHandler<ObterExportacaoResultadoProvasPorDataQuery, IEnumerable<ProvaExportacaoResultadoDto>>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;

        public ObterExportacaoResultadoProvasPorDataQueryHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new System.ArgumentNullException(nameof(repositorioExportacaoResultado));
        }
        

        public async Task<IEnumerable<ProvaExportacaoResultadoDto>> Handle(ObterExportacaoResultadoProvasPorDataQuery request, CancellationToken cancellationToken)
        {
            return await repositorioExportacaoResultado.ObterPorFiltroDataAsync(request.DataInicio, request.DataFim, request.ProvaSerapId);
        }
    }
}
