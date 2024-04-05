using MediatR;
using SME.SERAp.Prova.Infra;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoProvasPorDataPaginadaQuery : IRequest<PaginacaoResultadoDto<ExportacaoRetornoSerapDto>>
    {
        public ObterExportacaoResultadoProvasPorDataPaginadaQuery(FiltroExportacaoResultadoDto filtroExportacao)
        {
            DataInicio = filtroExportacao.DataInicio;
            DataFim = filtroExportacao.DataFim;
            ProvaSerapId = filtroExportacao.ProvaSerapId;
            DescricaoProva = filtroExportacao.DescricaoProva;
            QuantidadeRegistros = filtroExportacao.QuantidadeRegistros;
            NumeroPagina = filtroExportacao.NumeroPagina;
        }

        public DateTime? DataInicio { get; }
        public DateTime? DataFim { get; }
        public long ProvaSerapId { get; }
        public string DescricaoProva { get; }
        public int QuantidadeRegistros { get; }
        public int NumeroPagina { get; }
    }
}
