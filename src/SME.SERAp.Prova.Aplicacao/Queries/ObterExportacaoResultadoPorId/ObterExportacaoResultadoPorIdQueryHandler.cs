using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterExportacaoResultadoPorIdQueryHandler : IRequestHandler<ObterExportacaoResultadoPorIdQuery, ExportacaoResultado>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;
        public ObterExportacaoResultadoPorIdQueryHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new ArgumentNullException(nameof(repositorioExportacaoResultado));
        }
        public async Task<ExportacaoResultado> Handle(ObterExportacaoResultadoPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repositorioExportacaoResultado.ObterPorIdAsync(request.Id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Obter processo de exportação por id. Exportação Id:{request.Id}, ProvaSerapId:{request.ProvaSerapId}, Erro:{ex.Message}");
            }
        }
    }
}
