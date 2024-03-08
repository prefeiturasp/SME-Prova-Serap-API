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
    public class ObterUltimaVersaoFrontQueryHandler : IRequestHandler<ObterUltimaVersaoFrontQuery, string>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly GithubOptions githubOptions;
        private readonly IRepositorioCache repositorioCache;

        public ObterUltimaVersaoFrontQueryHandler(IHttpClientFactory httpClientFactory, GithubOptions githubOptions, IRepositorioCache repositorioCache)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.githubOptions = githubOptions ?? throw new ArgumentNullException(nameof(githubOptions));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<string> Handle(ObterUltimaVersaoFrontQuery request, CancellationToken cancellationToken)
        {
            var versaoFrontCache = await repositorioCache.ObterRedisAsync<VersaoRepositorioGitHubDto>(CacheChave.VersaoFront);
            if (versaoFrontCache != null && !string.IsNullOrEmpty(versaoFrontCache.Version))
                return versaoFrontCache.Version;

            const string versao = "Versão: 0";

            var httpClient = httpClientFactory.CreateClient("githubApi");
            var resposta = await httpClient.GetAsync($"repos/{githubOptions.RepositorioFront}/tags", cancellationToken);
            if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent) 
                return versao;
            
            var json = await resposta.Content.ReadAsStringAsync(cancellationToken);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var versoes = JsonSerializer.Deserialize<IEnumerable<VersaoGitHubRetornoDto>>(json, options);
            if (versoes == null || !versoes.Any())
                return versao;
            
            var versaoGitHub = versoes.FirstOrDefault().Name;
            if (string.IsNullOrEmpty(versaoGitHub))
                return versao;
            
            var versaoFront = new VersaoRepositorioGitHubDto
            {
                Version = versaoGitHub
            };
            await repositorioCache.SalvarRedisAsync(CacheChave.VersaoFront, versaoFront, 10080);
            return $"Versão: {versaoGitHub}";
        }
    }
}
