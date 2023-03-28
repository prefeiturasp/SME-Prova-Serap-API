using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class BaixarArquivoResultadoPspUseCase : AbstractUseCase, IBaixarArquivoResultadoPspUseCase
    {
        private readonly PathOptions pathOptions;

        public BaixarArquivoResultadoPspUseCase(IMediator mediator, PathOptions pathOptions) : base(mediator)
        {
            this.pathOptions = pathOptions ?? throw new ArgumentNullException(nameof(pathOptions));
        }

        public async Task<(byte[], string)> Executar(long processoId)
        {
            try
            {

                var processo = await mediator.Send(new ObterArquivoResultadoPspPorIdQuery(processoId));
                if (processo != null)
                {
                    string path = $"{pathOptions.PathArquivos}/ResultadoPsp/{processo.NomeArquivo}";
                    if (File.Exists(path))
                    {
                        var arquivo = await File.ReadAllBytesAsync(path);
                        if (arquivo != null)
                            return (arquivo, processo.NomeArquivo);
                    }

                    throw new NegocioException("Arquivo não encontrado");

                }
                throw new NegocioException("Processo não encontrado");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Baixar arquivo resultado PSP, processoId: {processoId} -- Erro:{ex.Message}");
            }
        }
    }
}
