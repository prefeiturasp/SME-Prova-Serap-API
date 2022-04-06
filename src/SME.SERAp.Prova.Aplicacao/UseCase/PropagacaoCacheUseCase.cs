using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class PropagacaoCacheUseCase : IPropagacaoCacheUseCase
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioPropagacaoCache repositorioPropagacaoCache;

        public PropagacaoCacheUseCase(IRepositorioCache repositorioCache, IRepositorioPropagacaoCache repositorioPropagacaoCache)
        {
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioPropagacaoCache = repositorioPropagacaoCache ?? throw new ArgumentNullException(nameof(repositorioPropagacaoCache));
        }

        public async Task Propagar()
        {
            Console.WriteLine($"~~> Inicializando WarmUp do cache as {DateTime.Now}");

            var minutosParaUmDia = (int)TimeSpan.FromDays(1).TotalMinutes;

            if (await DeveCriarOCachePara<IEnumerable<Dominio.Prova>>("p-*"))
            {
                var todasAsProvas = await repositorioPropagacaoCache.ObterTodasProvasParaCacheAsync();
                foreach (var prova in todasAsProvas)
                {
                    await repositorioCache.SalvarRedisAsync($"p-{prova.Id}", prova, minutosParaUmDia);
                }
            }

            if (await DeveCriarOCachePara<IEnumerable<Questao>>("q-*"))
            {
                IEnumerable<Questao> todasAsQuestoes = await repositorioPropagacaoCache.ObterTodasQuestoesParaCacheAsync();
                todasAsQuestoes.AsParallel().WithDegreeOfParallelism(3).ForAll(async questao =>
                {
                    await repositorioCache.SalvarRedisAsync($"q-{questao.Id}", JsonSerializer.Serialize(questao), minutosParaUmDia);
                });
            }

            if (await DeveCriarOCachePara<IEnumerable<Alternativa>>("a-*"))
            {
                IEnumerable<Alternativa> todasAsAlternativas = await repositorioPropagacaoCache.ObterTodasAlternativasParaCacheAsync();
                todasAsAlternativas.AsParallel().WithDegreeOfParallelism(3).ForAll(async alternativa =>
                {
                    await repositorioCache.SalvarRedisAsync($"a-{alternativa.Id}", JsonSerializer.Serialize(alternativa), minutosParaUmDia);
                });
            }

            if (await DeveCriarOCachePara<IEnumerable<Arquivo>>("ar-*"))
            {
                IEnumerable<Arquivo> todosOsArquivos = await repositorioPropagacaoCache.ObterTodosArquivosParaCacheAsync();
                foreach (var arquivo in todosOsArquivos)
                {
                    await repositorioCache.SalvarRedisAsync($"ar-{arquivo.LegadoId}", arquivo, minutosParaUmDia);
                }
            }

            Console.WriteLine($"~~> WarmUp do cache Finalizado as {DateTime.Now}");
        }

        private async Task<bool> DeveCriarOCachePara<T>(string chave)
        {
            return await repositorioCache.ObterRedisAsync<IEnumerable<Dominio.Prova>>(chave) != null;
        }
    }

}
