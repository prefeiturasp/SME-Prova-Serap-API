using MediatR;
using Microsoft.AspNetCore.Http;
using SME.SERAp.Prova.Infra;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ImportarArquivoResultadoPspUseCase : AbstractUseCase, IImportarArquivoResultadoPspUseCase
    {
        public ImportarArquivoResultadoPspUseCase(IMediator mediator) : base(mediator)
        {

        }

        public async Task<bool> Executar(IFormFile arquivo, ImportArquivoResultadoPspDto arquivoResultadoDto)
        {
            try
            {

                if (arquivo == null || arquivo?.Length == 0) return false;
                if (arquivoResultadoDto == null) return false;
                if (string.IsNullOrEmpty(arquivoResultadoDto.NomeArquivo) || string.IsNullOrEmpty(arquivoResultadoDto.PathArquivo)) return false;

                string caminhoBaseArquivos = $"{Environment.GetEnvironmentVariable("PathResultadoPsp")}\\ResultadoPsp";
                string pastaArquivo = $"{caminhoBaseArquivos}\\{arquivoResultadoDto.PathArquivo}";
                if (!Directory.Exists(pastaArquivo))
                {
                    Directory.CreateDirectory(pastaArquivo);
                }
                using (FileStream filestream = File.Create($"{pastaArquivo}\\{arquivoResultadoDto.NomeArquivo}"))
                {
                    await arquivo.CopyToAsync(filestream);
                    filestream.Flush();
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
