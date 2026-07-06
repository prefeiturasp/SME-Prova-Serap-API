using Microsoft.AspNetCore.Http;

namespace SME.SERAp.Prova.Infra
{
    public class ImportArquivoResultadoPspDto : DtoBase
    {
        public ImportArquivoResultadoPspDto()
        {

        }

        public IFormFile Arquivo { get; set; }
        public string NomeArquivo { get; set; }
    }
}