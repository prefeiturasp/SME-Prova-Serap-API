using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra.Dtos.ResultadoPsp
{
    public class UploadArquivoResultadoPspRequest
    {
        public IFormFile Arquivo { get; set; }
        public string NomeArquivo { get; set; }
    }
}