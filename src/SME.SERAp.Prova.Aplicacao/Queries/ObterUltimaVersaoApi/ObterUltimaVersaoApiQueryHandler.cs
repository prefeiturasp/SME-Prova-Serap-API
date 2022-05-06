using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaVersaoApiQueryHandler : IRequestHandler<ObterUltimaVersaoApiQuery, string>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly GithubOptions githubOptions;
        private readonly IRepositorioCache repositorioCache;
        
        public ObterUltimaVersaoApiQueryHandler(IHttpClientFactory httpClientFactory, GithubOptions githubOptions, IRepositorioCache repositorioCache)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.githubOptions = githubOptions ?? throw new ArgumentNullException(nameof(githubOptions));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<string> Handle(ObterUltimaVersaoApiQuery request, CancellationToken cancellationToken)
        {
            var versaoApi = "Versão: 0";

            var versaoApiCache = await repositorioCache.ObterRedisAsync<string>(CacheChave.VersaoApi);

            if (string.IsNullOrEmpty(versaoApiCache))
            {
                var httpClient = httpClientFactory.CreateClient("githubApi");

                var resposta = await httpClient.GetAsync($"repos/{githubOptions.RepositorioApi}/tags", cancellationToken);

                if (resposta.IsSuccessStatusCode && resposta.StatusCode != HttpStatusCode.NoContent)
                {
                    var json = await resposta.Content.ReadAsStringAsync(cancellationToken);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var versoes = JsonSerializer.Deserialize<IEnumerable<VersaoGitHubRetornoDto>>(json, options);

                    if (versoes.Any())
                        versaoApi = $"Versão: {versoes.FirstOrDefault().Name}";

                    await repositorioCache.SalvarRedisAsync(CacheChave.VersaoApi, versaoApi, 10080);
                }

            }
            else versaoApi = versaoApiCache;

            return versaoApi;
        }
    }
}
