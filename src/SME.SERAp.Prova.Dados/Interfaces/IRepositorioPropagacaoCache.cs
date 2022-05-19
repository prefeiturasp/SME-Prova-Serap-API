using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioPropagacaoCache
    {
        Task<IEnumerable<Dominio.Prova>> ObterProvasLiberadasNoPeriodoParaCacheAsync(DateTime dataHoraAtual);
        Task<IEnumerable<QuestaoCompletaDto>> ObterQuestaoCompletaParaCacheAsync(long[] provaIds);
        Task<IEnumerable<QuestaoResumoProvaDto>> ObterQuestaoResumoParaCacheAsync(long[] provaIds);
        Task<IEnumerable<Dominio.ParametroSistema>> ObterParametrosParaCacheAsync();
        Task<IEnumerable<ProvaAnoDto>> ObterProvasAnosDatasEModalidadesParaCacheAsync();
    }
}
