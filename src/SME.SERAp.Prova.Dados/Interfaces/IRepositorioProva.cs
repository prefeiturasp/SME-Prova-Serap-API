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
        Task<IEnumerable<ProvaAnoDto>> ObterAnosDatasEModalidadesAsync();
        Task<bool> VerificaSeExistePorProvaSerapId(long provaId);
        Task<List<ProvaAnoDto>> ObterProvasAdesaoAlunoAsync(long alunoRa, long turmaId);
        Task<PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>> ObterProvasPaginada(ProvaAdmFiltroDto provaAdmFiltroDto, bool inicioFuturo, Guid? perfil, string login);
        Task<IEnumerable<ProvaResultadoResumoDto>> ObterResultadoResumoProvaAsync(long provaId, long alunoRa);
        Task<IEnumerable<ProvaTaiResultadoDto>> ObterResultadoResumoProvaTaiAsync(long provaId, long alunoRa);
    }
}
