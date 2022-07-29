using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioPropagacaoCache
    {
        Task<IEnumerable<Dominio.Prova>> ObterProvasLiberadasNoPeriodoParaCacheAsync();
        Task<IEnumerable<QuestaoCompleta>> ObterQuestaoCompletaParaCacheAsync(long[] provaIds);
        Task<IEnumerable<QuestaoResumoProvaDto>> ObterQuestaoResumoParaCacheAsync(long[] provaIds);
        Task<IEnumerable<Dominio.ParametroSistema>> ObterParametrosParaCacheAsync();
        Task<IEnumerable<ProvaAnoDto>> ObterProvasAnosDatasEModalidadesParaCacheAsync();
        Task InserirTabelaJson(long questaoId, string json);
        Task<IEnumerable<QuestaoCompleta>> ObterQuestaoCompletaLegadoParaCacheAsync(long[] provaIds);
    }
}
