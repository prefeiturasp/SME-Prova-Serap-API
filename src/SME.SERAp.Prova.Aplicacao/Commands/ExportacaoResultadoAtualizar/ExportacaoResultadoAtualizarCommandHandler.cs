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
        private readonly IRepositorioCache repositorioCache;

        public ExportacaoResultadoAtualizarCommandHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado, IRepositorioCache repositorioCache)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new ArgumentNullException(nameof(repositorioExportacaoResultado));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<long> Handle(ExportacaoResultadoAtualizarCommand request, CancellationToken cancellationToken)
        {            
            var result = await repositorioExportacaoResultado.UpdateAsync(request.ExportacaoResultado);
            await repositorioCache.RemoverRedisAsync($"exportacao-{request.ExportacaoResultado.Id}-prova-{request.ExportacaoResultado.ProvaSerapId}");
            return result;
        }
    }
}