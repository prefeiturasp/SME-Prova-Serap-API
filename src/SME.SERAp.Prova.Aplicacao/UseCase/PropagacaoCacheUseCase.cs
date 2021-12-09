using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PropagacaoCacheUseCase : IPropagacaoCacheUseCase
    {
        private readonly IRepositorioProva repositorioProva;
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioQuestao repositorioQuestao;
        private readonly IRepositorioAlternativa repositorioAlternativa;
        private readonly IRepositorioArquivo repositorioArquivo;

        public PropagacaoCacheUseCase(IRepositorioProva repositorioProva, IRepositorioCache repositorioCache, IRepositorioQuestao repositorioQuestao,
            IRepositorioAlternativa repositorioAlternativa, IRepositorioArquivo repositorioArquivo)
        {
            this.repositorioProva = repositorioProva ?? throw new ArgumentNullException(nameof(repositorioProva));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
            this.repositorioAlternativa = repositorioAlternativa ?? throw new ArgumentNullException(nameof(repositorioAlternativa));
            this.repositorioArquivo = repositorioArquivo ?? throw new ArgumentNullException(nameof(repositorioArquivo));
        }
        public async Task Propagar()
        {
            Console.WriteLine($"~~> Inicializando WarmUp do cache as {DateTime.Now}");

            var minutosParaUmDia = (int)TimeSpan.FromDays(1).TotalMinutes;

            var todasAsProvas = await repositorioProva.ObterTodasParaCacheAsync();
            foreach (var prova in todasAsProvas)
            {
                await repositorioCache.SalvarAsync($"p-{prova.Id}", prova, minutosParaUmDia);
            }

            IEnumerable<Questao> todasAsQuestoes = await repositorioQuestao.ObterTodasParaCacheAsync();
            todasAsQuestoes.AsParallel().WithDegreeOfParallelism(3).ForAll(questao =>
            {
                repositorioCache.Salvar($"q-{questao.Id}", JsonSerializer.Serialize(questao), minutosParaUmDia);
            });

            IEnumerable<Alternativa> todasAsAlternativas = await repositorioAlternativa.ObterTodosParaCacheAsync();
            todasAsAlternativas.AsParallel().WithDegreeOfParallelism(3).ForAll(alternativa =>
            {
                repositorioCache.Salvar($"a-{alternativa.Id}", JsonSerializer.Serialize(alternativa), minutosParaUmDia);
            });

            IEnumerable<Arquivo> todosOsArquivos = await repositorioArquivo.ObterTodosParaCacheAsync();
            foreach (var arquivo in todosOsArquivos)
            {
                await repositorioCache.SalvarAsync($"ar-{arquivo.LegadoId}", arquivo, minutosParaUmDia);
            }

            Console.WriteLine($"~~> WarmUp do cache Finalizado as {DateTime.Now}");
        }
    }

}
