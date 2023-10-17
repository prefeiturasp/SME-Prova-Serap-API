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

                Administrado = request.Administrado.Length == 0 ? "NA" : string.Join(",", request.Administrado.Distinct()),
                Respostas = request.Respostas.Length == 0 ? "NA" : string.Join(",", request.Respostas.Distinct()),
                Gabarito = request.Gabarito.Length == 0 ? "NA" : string.Join(",", request.Gabarito.Distinct()),

                ErroPadrao = "0.35",

                NIj = request.NIj,
                Componente = request.Componente
            };

            var json = JsonSerializer.Serialize(obterItensProvaTaiDto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiROptions.UrlQuestao, stringContent, cancellationToken);

            if (!response.IsSuccessStatusCode) 
                throw new Exception("Não foi possível obter os dados");
            
            var result = await response.Content.ReadAsStringAsync(cancellationToken);

            var resposta = result
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Replace("\"", string.Empty)
                .Split(",");

            var proximaQuestao = long.Parse(resposta[0].Replace("NA", "-1"), CultureInfo.InvariantCulture);
            var ordem = int.Parse(resposta[1].Replace("NA", "0"), CultureInfo.InvariantCulture);
            var posicaoProximoItem = int.Parse(resposta[2].Replace("NA", "0"), CultureInfo.InvariantCulture);
            var parA = decimal.Parse(resposta[3].Replace("NA", decimal.Zero.ToString(CultureInfo.InvariantCulture)), CultureInfo.InvariantCulture);
            var parB = decimal.Parse(resposta[4].Replace("NA", decimal.Zero.ToString(CultureInfo.InvariantCulture)), CultureInfo.InvariantCulture);
            var parC = decimal.Parse(resposta[5].Replace("NA", decimal.Zero.ToString(CultureInfo.InvariantCulture)), CultureInfo.InvariantCulture);

            var proficiencia = decimal.Parse(resposta[6]
                .Replace("NA", decimal.Zero.ToString(CultureInfo.InvariantCulture))
                .Replace("e-", "00"), CultureInfo.InvariantCulture);

            var erroMedida = decimal.Parse(resposta[7]
                .Replace("NA", decimal.Zero.ToString(CultureInfo.InvariantCulture)), CultureInfo.InvariantCulture);

            return new ObterProximoItemApiRRespostaDto
            {
                ProximaQuestao = proximaQuestao,
                Ordem = ordem == 0 ? ordem : ordem - 1,
                PosicaoProximoItem = posicaoProximoItem,
                ParA = parA,
                ParB = parB,
                ParC = parC,
                Proficiencia = proficiencia,
                ErroMedida = erroMedida
            };
        }
    }
}
