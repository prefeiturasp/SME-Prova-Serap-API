using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioProva : IRepositorioBase<Dominio.Prova>
    {
        Task<Dominio.Prova> ObterPorIdLegadoAsync(long id);
        Task<IEnumerable<Dominio.Prova>> ObterPorAnoData(int ano, DateTime dataReferenia);
        Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> ObterDetalhesResumoPorIdAsync(long id);
        Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> ObterDetalhesResumoBIBPorIdERaAsync(long provaId, long alunoRA);
        Task<string> ObterCadernoAlunoPorProvaIdRa(long provaId, long alunoRA);
        Task<IEnumerable<Dominio.Prova>> ObterPorAnoDataEModalidade(string ano, DateTime dataReferenia, int modalidade);
        Task<IEnumerable<Dominio.Prova>> ObterTodasParaCacheAsync();
    }
}
