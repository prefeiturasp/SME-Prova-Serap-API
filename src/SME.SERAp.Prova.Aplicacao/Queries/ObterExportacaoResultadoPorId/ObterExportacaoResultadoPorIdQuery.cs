using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoPorIdQuery : IRequest<ExportacaoResultado>
    {
        public ObterExportacaoResultadoPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
        public long ProvaSerapId { get; set; }
    }
}
