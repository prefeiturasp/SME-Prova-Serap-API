using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExportacaoResultadoAtualizarCommandHandler : IRequestHandler<ExportacaoResultadoAtualizarCommand, long>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;

        public ExportacaoResultadoAtualizarCommandHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new ArgumentNullException(nameof(repositorioExportacaoResultado));
        }

        public async Task<long> Handle(ExportacaoResultadoAtualizarCommand request, CancellationToken cancellationToken)
        {
            return await repositorioExportacaoResultado.UpdateAsync(request.ExportacaoResultado);
        }
    }
}