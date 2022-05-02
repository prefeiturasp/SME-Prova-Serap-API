using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class PropagacaoCacheUseCase : IPropagacaoCacheUseCase
    {
        private readonly IServicoLog servicoLog;
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioPropagacaoCache repositorioPropagacaoCache;

        public PropagacaoCacheUseCase(IServicoLog servicoLog, IRepositorioCache repositorioCache, IRepositorioPropagacaoCache repositorioPropagacaoCache)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioPropagacaoCache = repositorioPropagacaoCache ?? throw new ArgumentNullException(nameof(repositorioPropagacaoCache));
        }

        public async Task Propagar()
        {
            try
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
            catch (Exception ex)
            {
                servicoLog.Registrar($"Propagacao Cache erro no acesso ao redis durante o warmUp do pod. Erro original: {ex.Message}");
                servicoLog.Registrar(ex);
            }
        }

        private async Task<bool> DeveCriarOCachePara<T>(string chave)
        {
            return await repositorioCache.ObterRedisAsync<T>(chave) != null;
        }
    }
}
