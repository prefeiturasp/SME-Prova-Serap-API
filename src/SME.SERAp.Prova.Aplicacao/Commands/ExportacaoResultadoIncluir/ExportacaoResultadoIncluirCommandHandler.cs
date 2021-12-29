using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExportacaoResultadoIncluirCommandHandler : IRequestHandler<ExportacaoResultadoIncluirCommand, long>
    {
        private readonly IRepositorioExportacaoResultado repositorioExportacaoResultado;
        private readonly IRepositorioCache repositorioCache;

        public ExportacaoResultadoIncluirCommandHandler(IRepositorioExportacaoResultado repositorioExportacaoResultado, IRepositorioCache repositorioCache)
        {
            this.repositorioExportacaoResultado = repositorioExportacaoResultado ?? throw new ArgumentNullException(nameof(repositorioExportacaoResultado));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<long> Handle(ExportacaoResultadoIncluirCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exportacao = request.ExportacaoResultado;
                exportacao.Id = await repositorioExportacaoResultado.IncluirAsync(request.ExportacaoResultado);
                await repositorioCache.SalvarRedisAsync($"exportacao-{exportacao.Id}-prova-{exportacao.ProvaSerapId}-status", (int)exportacao.Status);
                return exportacao.Id;
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Erro ao criar processo de exportação - Erro:{ex.Message}");
            }            
        }        
    }
}