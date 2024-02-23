﻿using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoProvasPorDataPaginadaQuery : IRequest<IEnumerable<ExportacaoRetornoSerapDto>>
    {
        public ObterExportacaoResultadoProvasPorDataPaginadaQuery(FiltroExportacaoResultadoDto filtroExportacao)
        {
            DataInicio = filtroExportacao.DataInicio;
            DataFim = filtroExportacao.DataFim;
            ProvaSerapId = filtroExportacao.ProvaSerapId;
            QuantidadeRegistros = filtroExportacao.QuantidadeRegistros;
            NumeroPagina = filtroExportacao.NumeroPagina;
        }

        public DateTime? DataInicio { get; }
        public DateTime? DataFim { get; }
        public long ProvaSerapId { get; }
        public int QuantidadeRegistros { get; }
        public int NumeroPagina { get; }
    }
}
