using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;
using System;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioTipoDeficiencia : IRepositorioBase<TipoDeficiencia>
    {
        Task<TipoDeficiencia> ObterPorLegadoId(Guid legadoId);
        Task<TipoDeficiencia> ObterPorCodigoEol(int codigoEol);

        Task<IEnumerable<TipoDeficiencia>> ObterPorAlunoRa(long alunoRa);

        Task<IEnumerable<TipoDeficienciaProvaDto>> ObterPorProvaIds(long[] provaIds);
    }
}
