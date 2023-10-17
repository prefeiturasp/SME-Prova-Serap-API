using MediatR;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class TesteConexaoApiRQueryHandler : IRequestHandler<TesteConexaoApiRQuery, bool>
    {
        private readonly ApiROptions apiROptions;
        private readonly IServicoLog servicoLog;

        public TesteConexaoApiRQueryHandler(ApiROptions apiROptions, IServicoLog servicoLog)
        {
            this.apiROptions = apiROptions ?? throw new ArgumentNullException(nameof(apiROptions));
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<bool> Handle(TesteConexaoApiRQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.PostAsync(apiROptions.UrlPing, new StringContent("teste"), cancellationToken);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar($"Erro ao conectar na API R -- {ex.Message}.", ex);
                return false;
            }
        }
    }
}
