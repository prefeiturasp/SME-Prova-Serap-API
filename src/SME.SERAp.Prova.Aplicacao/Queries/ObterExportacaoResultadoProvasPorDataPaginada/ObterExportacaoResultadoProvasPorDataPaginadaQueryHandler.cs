using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
   public class ObterExportacaoResultadoProvasPorDataPaginadaQueryHandler : IRequestHandler<ObterExportacaoResultadoProvasPorDataPaginadaQuery, PaginacaoResultadoDto<ExportacaoRetornoSerapDto>>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;

        public ObterExportacaoResultadoProvasPorDataPaginadaQueryHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new ArgumentNullException(nameof(repositorioExportacaoResultado));
        }

        public async Task<PaginacaoResultadoDto<ExportacaoRetornoSerapDto>> Handle(ObterExportacaoResultadoProvasPorDataPaginadaQuery request, CancellationToken cancellationToken)
        {
            var quantidadeRegistros = request.QuantidadeRegistros <= 0 ? 10 : request.QuantidadeRegistros;
            var numeroPagina = request.NumeroPagina <= 0 ? 1 : request.NumeroPagina;

            var result = await repositorioExportacaoResultado.ObterPorFiltroDataPaginadaAsync(request.DataInicio,
                request.DataFim, request.ProvaSerapId, quantidadeRegistros, numeroPagina);

            var retorno = new PaginacaoResultadoDto<ExportacaoRetornoSerapDto>
            {
                Items = result.Items.Select(x => new ExportacaoRetornoSerapDto
                {
                    Test_Id = x.ProvaLegadoId,
                    TestDescription = x.NomeProva,
                    ApplicationStartDate = x.DataInicio.ToString("dd/MM/yyyy"),
                    ApplicationEndDate = x.DataFim.ToString("dd/MM/yyyy"),
                    TestTypeDescription = string.Empty,
                    StateExecution = (int)x.Status,
                    CreateDate = string.Empty,
                    UpdateDate = string.Empty,
                    FileId = x.ProcessoId,
                }),
                TotalRegistros = result.TotalRegistros,
                TotalPaginas = result.TotalPaginas
            };

            return retorno;
        }
    }
}
