using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Linq;
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
            bool progagandoCache = false;
            try
            {
                var dataHoraAtual = DateTime.Now;
                Console.WriteLine($"~~> Inicializando WarmUp do cache as {dataHoraAtual}");

                var minutosParaUmDia = (int)TimeSpan.FromDays(1).TotalMinutes;
                if (!await repositorioCache.ExisteChaveAsync(CacheChave.CachePropagado))
                {
                    progagandoCache = true;
                    await repositorioCache.SalvarRedisAsync(CacheChave.CachePropagado, true, minutosParaUmDia);

                    var parametros = await repositorioPropagacaoCache.ObterParametrosParaCacheAsync();
                    await repositorioCache.SalvarRedisAsync(CacheChave.Parametros, parametros, minutosParaUmDia);

                    var provasAnosDatasEModalidades = await repositorioPropagacaoCache.ObterProvasAnosDatasEModalidadesParaCacheAsync();
                    await repositorioCache.SalvarRedisAsync(CacheChave.ProvasAnosDatasEModalidades, provasAnosDatasEModalidades, minutosParaUmDia);

                    var provas = await repositorioPropagacaoCache.ObterProvasLiberadasNoPeriodoParaCacheAsync();
                    foreach (var prova in provas)
                    {
                        await repositorioCache.SalvarRedisAsync(string.Format(CacheChave.Prova, prova.Id), prova, minutosParaUmDia);
                    }

                    var provasIds = provas.Select(p => p.Id).ToArray();

                    if (provasIds.Any())
                    {
                        var questoesResumo = await repositorioPropagacaoCache.ObterQuestaoResumoParaCacheAsync(provasIds);

                        foreach (var provaId in provasIds)
                        {
                            var questapResumoProva = questoesResumo.Where(t => t.ProvaId == provaId).ToList();

                            foreach (var questaoResumo in questoesResumo)
                                await repositorioCache.SalvarRedisAsync(string.Format(CacheChave.QuestaoProvaResumo, provaId, questaoResumo.Caderno), questapResumoProva, minutosParaUmDia);    
                        }

                        var questoesCompletas = await repositorioPropagacaoCache.ObterQuestaoCompletaParaCacheAsync(provasIds);
                        foreach (var questao in questoesCompletas)
                        {
                            await repositorioCache.SalvarRedisToJsonAsync(string.Format(CacheChave.QuestaoCompleta, questao.Id), questao.Json, minutosParaUmDia);
                        }

                        var questoesCompletasLegado = await repositorioPropagacaoCache.ObterQuestaoCompletaLegadoParaCacheAsync(provasIds);
                        foreach (var questao in questoesCompletasLegado)
                        {
                            await repositorioCache.SalvarRedisToJsonAsync(string.Format(CacheChave.QuestaoCompletaLegado, questao.Id), questao.Json, minutosParaUmDia);
                        }
                    }
                }

                Console.WriteLine($"~~> WarmUp do cache Finalizado as {DateTime.Now}");
            }
            catch (Exception ex)
            {
                servicoLog.Registrar("Erro ao Propagar os dados para o cache durante o warmUp do pod", ex);

                if (progagandoCache)
                    await repositorioCache.RemoverRedisAsync(CacheChave.CachePropagado);
            }
        }
    }
}
