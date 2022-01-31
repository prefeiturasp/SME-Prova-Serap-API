using MediatR;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class DownloadArquivoResultadoProvaUseCase : IDownloadArquivoResultadoProvaUseCase
    {
        private readonly IMediator mediator;
        public DownloadArquivoResultadoProvaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<(byte[], string)> Executar(long Id)
        {
            try
            {
                var exportacaoResultado = await mediator.Send(new ObterExportacaoResultadoPorIdQuery(Id));
                var pathResultados = Environment.GetEnvironmentVariable("PathResultadosExportacaoSerap");
                string caminhoCompleto = Path.Combine(pathResultados, exportacaoResultado.NomeArquivo);

                if (File.Exists(caminhoCompleto))
                {
                    var arquivo = await File.ReadAllBytesAsync(caminhoCompleto);

                    if (arquivo != null)
                        return (arquivo, $"Prova{exportacaoResultado.ProvaSerapId}_{exportacaoResultado.Id}.csv");
                }

                throw new NegocioException("Não foi possível fazer download. Arquivo não localizado.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Download arquivo -- {ex.Message}");
            }
        }
    }
}
