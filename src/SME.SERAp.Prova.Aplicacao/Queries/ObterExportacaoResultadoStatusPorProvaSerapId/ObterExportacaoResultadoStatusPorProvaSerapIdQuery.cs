using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoStatusPorProvaSerapIdQuery : IRequest<ExportacaoResultado>
    {
        public ObterExportacaoResultadoStatusPorProvaSerapIdQuery(long provaSerapId)
        {
            ProvaSerapId = provaSerapId;
        }

        public long Id { get; set; }
        public long ProvaSerapId { get; set; }
    }
}
