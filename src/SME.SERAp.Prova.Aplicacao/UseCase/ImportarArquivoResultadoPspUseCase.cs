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
                if (string.IsNullOrEmpty(arquivoResultadoDto.NomeArquivo)) return false;

                string caminhoBaseArquivos = $"{Environment.GetEnvironmentVariable("PathArquivos")}\\ResultadoPsp";
                if (!Directory.Exists(caminhoBaseArquivos))
                {
                    Directory.CreateDirectory(caminhoBaseArquivos);
                }
                using (FileStream filestream = File.Create($"{caminhoBaseArquivos}\\{arquivoResultadoDto.NomeArquivo}"))
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
