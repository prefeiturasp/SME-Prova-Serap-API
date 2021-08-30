using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/arquivos")]
    public class ArquivoController : Controller
    {
        [HttpGet("provas/{provaId}")]
        [ProducesResponseType(typeof(IEnumerable<long>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        //[Authorize("Bearer")]
        public async Task<IActionResult> ObterArquivosProvas(long provaId)
        {
            var arquivos = new List<long>() {
                1,2,3
            };
            return Ok(arquivos);
        }

        [HttpGet("{arquivoId}")]
        [ProducesResponseType(typeof(ArquivoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        //[Authorize("Bearer")]
        public async Task<IActionResult> ObterPorId(long arquivoId)
        {
            var arquivos = new List<ArquivoDto>() {
                new ArquivoDto("Teste 1", "https://images.unsplash.com/photo-1604263439201-171fb8c0fddc?rnd=", 1),
                new ArquivoDto("Teste 2", "https://images.unsplash.com/photo-1604164388977-1b6250ef26f3?rnd=", 2),
                new ArquivoDto("Teste PDF", "https://dev-sr-relatorios.sme.prefeitura.sp.gov.br/api/v1/downloads/sgp/pdf/Ata%20de%20resultados%20finais.pdf/0073ea5f-201e-45e0-aef7-86b82fc4c37e", 3)
            };
            return Ok(arquivos.FirstOrDefault(a => a.Id == arquivoId));
        }
    }
}
