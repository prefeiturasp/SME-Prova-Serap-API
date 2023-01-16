using Microsoft.AspNetCore.Http;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IImportarArquivoResultadoPspUseCase
    {
        Task<bool> Executar(IFormFile arquivo, ImportArquivoResultadoPspDto arquivoResultadoDto);
    }
}
