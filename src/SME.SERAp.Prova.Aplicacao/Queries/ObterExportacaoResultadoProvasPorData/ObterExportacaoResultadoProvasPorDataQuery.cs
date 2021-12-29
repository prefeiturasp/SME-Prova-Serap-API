using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoProvasPorDataQuery : IRequest<IEnumerable<ProvaExportacaoResultadoDto>>
    {
        public ObterExportacaoResultadoProvasPorDataQuery(FiltroExportacaoResultadoDto filtroExportacao)
        {
            DataInicio = filtroExportacao.DataInicio;
            DataFim = filtroExportacao.DataFim;
            ProvaSerapId = filtroExportacao.ProvaSerapId;
        }

        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public long? ProvaSerapId { get; set; }


    }
}
