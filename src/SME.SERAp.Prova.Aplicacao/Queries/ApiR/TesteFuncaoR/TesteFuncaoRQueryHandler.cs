using MediatR;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class TesteFuncaoRQueryHandler : IRequestHandler<TesteFuncaoRQuery, string>
    {
        public TesteFuncaoRQueryHandler(){}

        public async Task<string> Handle(TesteFuncaoRQuery request, CancellationToken cancellationToken)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"https://dev-serap-estudante.sme.prefeitura.sp.gov.br/potenciacao?base={request.Base}&expoente={request.Expoente}");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), client.BaseAddress.AbsoluteUri);
                requestMessage.Headers.Accept.Clear();
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;                    
                }
                throw new Exception("Não foi possível obter os dados");
            }
            catch(Exception e)
            {
                throw new ArgumentException($"Erro no teste da função R Potenciação -- {e.Message}.");
            }
        }
    }
}
