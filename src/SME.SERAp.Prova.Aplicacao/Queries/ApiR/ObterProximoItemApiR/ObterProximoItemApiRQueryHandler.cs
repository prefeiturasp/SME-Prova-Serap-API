using MediatR;
using SME.SERAp.Prova.Infra.Dtos.ApiR;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProximoItemApiRQueryHandler : IRequestHandler<ObterProximoItemApiRQuery, ObterProximoItemApiRRespostaDto>
    {
        private readonly ApiROptions apiROptions;

        public ObterProximoItemApiRQueryHandler(ApiROptions apiROptions)
        {
            this.apiROptions = apiROptions ?? throw new ArgumentNullException(nameof(apiROptions));
        }

        public async Task<ObterProximoItemApiRRespostaDto> Handle(ObterProximoItemApiRQuery request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            var obterItensProvaTaiDto = new ObterProximaQuestaoTaiDto
            {
                Estudante = request.Estudante,
                AnoEscolarEstudante = request.AnoEscolarEstudante,
                Proficiencia = request.Proficiencia.ToString(CultureInfo.InvariantCulture),
                ProficienciaInicial = request.Proficiencia.ToString(CultureInfo.InvariantCulture),
                IdItem = string.Join(",", request.IdItem),
                ParA = string.Join(",", request.ParA.Select(t => t.ToString(CultureInfo.InvariantCulture))),
                ParB = string.Join(",", request.ParB.Select(t => t.ToString(CultureInfo.InvariantCulture))),
                ParC = string.Join(",", request.ParC.Select(t => t.ToString(CultureInfo.InvariantCulture))),

                Administrado = string.Join(",", request.Administrado),
                Respostas = string.Join(",", request.Respostas),
                Gabarito = string.Join(",", request.Gabarito),

                ErroPadrao = "0.35",

                NIj = request.NIj
            };

            var json = JsonSerializer.Serialize(obterItensProvaTaiDto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiROptions.UrlQuestao, stringContent, cancellationToken);

            if (!response.IsSuccessStatusCode) 
                throw new Exception("Não foi possível obter os dados");
            
            var result = await response.Content.ReadAsStringAsync(cancellationToken);

            var resposta = result
                .Replace("[", "")
                .Replace("]", "")
                .Split(",");

            return new ObterProximoItemApiRRespostaDto
            {
                ProximaQuestao = long.Parse(resposta[0]),
                Ordem = int.Parse(resposta[1]),
                ParA = decimal.Parse(resposta[3], CultureInfo.InvariantCulture),
                ParB = decimal.Parse(resposta[4], CultureInfo.InvariantCulture),
                ParC = Convert.ToDecimal(resposta[5], CultureInfo.InvariantCulture),
                Proficiencia = Convert.ToDecimal(resposta[6].Replace("e-", "00"), CultureInfo.InvariantCulture)
            };
        }
    }
}
