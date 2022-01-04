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
            var exportacaoResultado = await mediator.Send(new ObterExportacaoResultadoPorIdQuery(Id));
            var pathResultados = Environment.GetEnvironmentVariable("PathResultadosExportacaoSerap");
            string filePath = new Uri(pathResultados).AbsolutePath;
            string physicalPath = filePath.Replace("/", "\\");
            var nomeArquivo = Path.Combine(physicalPath, exportacaoResultado.NomeArquivo);

            if (File.Exists(nomeArquivo))
            {
                var arquivo = await File.ReadAllBytesAsync(nomeArquivo);

                if (arquivo != null)
                    return (arquivo, $"Prova{exportacaoResultado.ProvaSerapId}_{exportacaoResultado.Id}.csv");
            }

            throw new NegocioException("Não foi possível fazer download do arquivo");
        }
    }
}
