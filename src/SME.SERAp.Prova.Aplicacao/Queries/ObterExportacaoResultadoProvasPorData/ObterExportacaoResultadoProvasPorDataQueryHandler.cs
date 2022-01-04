using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
   public class ObterExportacaoResultadoProvasPorDataQueryHandler : IRequestHandler<ObterExportacaoResultadoProvasPorDataQuery, IEnumerable<ExportacaoRetornoSerapDto>>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;

        public ObterExportacaoResultadoProvasPorDataQueryHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new ArgumentNullException(nameof(repositorioExportacaoResultado));
        }
        

        public async Task<IEnumerable<ExportacaoRetornoSerapDto>> Handle(ObterExportacaoResultadoProvasPorDataQuery request, CancellationToken cancellationToken)
        {
            var result = await repositorioExportacaoResultado.ObterPorFiltroDataAsync(request.DataInicio, request.DataFim, request.ProvaSerapId);

            return result?.Select(x => new ExportacaoRetornoSerapDto
            {
                Test_Id = x.ProvaLegadoId,
                TestDescription = x.NomeProva,
                TestTypeDescription = string.Empty,
                StateExecution = (int)x.Status,
                CreateDate = string.Empty,
                UpdateDate = string.Empty,
                FileId = x.ProcessoId,
            });
        }
    }
}
