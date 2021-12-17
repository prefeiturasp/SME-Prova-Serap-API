using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoStatusPorProvaSerapIdQueryHandler : IRequestHandler<ObterExportacaoResultadoStatusPorProvaSerapIdQuery, ExportacaoResultado>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;

        public ObterExportacaoResultadoStatusPorProvaSerapIdQueryHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new System.ArgumentNullException(nameof(repositorioExportacaoResultado));
        }
        public async Task<ExportacaoResultado> Handle(ObterExportacaoResultadoStatusPorProvaSerapIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioExportacaoResultado.ObterPorProvaSerapIdAsync(request.ProvaSerapId);
        }
    }
}
