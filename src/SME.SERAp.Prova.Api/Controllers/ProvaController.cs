using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/provas")]
    public class ProvaController : ControllerBase
    {
        private readonly CryptographyOptions cryptographyOptions;

        public ProvaController(IOptions<CryptographyOptions> cryptographyOptions)
        {
            this.cryptographyOptions = cryptographyOptions?.Value ?? new CryptographyOptions();
        }

        [HttpGet("AplicarAES")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> AplicarAES(string senha)
        {
            var byteResult = cryptographyOptions.EncryptStringToBytes_Aes(senha, cryptographyOptions.KeyBytes, cryptographyOptions.IVBytes);
            var value = cryptographyOptions.DecryptStringFromBytes_Aes(byteResult, cryptographyOptions.KeyBytes, cryptographyOptions.IVBytes);
            return Ok(new { senha = senha, cifrada = cryptographyOptions.ByteArrayToString(byteResult), comparacao = value });
        }

        [HttpGet("AplicarMD5")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> AplicarMD5(string senha)
        {
            using (var md5 = MD5.Create())
            {
                md5.Initialize();
                var byteResult = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));
                var stringResult = string.Join("", byteResult.Select(x => x.ToString("x2")));
                return Ok(stringResult);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ObterProvasRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvas([FromServices] IObterProvasAreaEstudanteUseCase obterProvasAreaEstudanteUseCase)
        {
            return Ok(await obterProvasAreaEstudanteUseCase.Executar());
        }

        [HttpGet("{id}/detalhes-resumido")]
        [ProducesResponseType(typeof(IEnumerable<ProvaDetalheResumidoRetornoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterDetalhesResumido(long id, [FromServices] IObterProvaDetalhesResumidoUseCase obterProvaDetalhesResumidoUseCase)
        {
            return Ok(await obterProvaDetalhesResumidoUseCase.Executar(id));
        }

        [HttpGet("{provaId}/status-aluno")]
        [ProducesResponseType(typeof(ProvaAlunoDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> ObterProvaStatusDoAluno(long provaId, [FromServices] IObterProvaAlunoUseCase obterProvaAlunoUseCase)
        {
            return Ok(await obterProvaAlunoUseCase.Executar(provaId));
        }

        [HttpPost("{provaId}/status-aluno")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Authorize("Bearer")]
        public async Task<IActionResult> SalvarProvaStatusDoAluno(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto, [FromServices] IIncluirProvaAlunoUseCase incluirProvaAlunoUseCase)
        {
            return Ok(await incluirProvaAlunoUseCase.Executar(provaId, provaAlunoStatusDto));
        }
    }
}
