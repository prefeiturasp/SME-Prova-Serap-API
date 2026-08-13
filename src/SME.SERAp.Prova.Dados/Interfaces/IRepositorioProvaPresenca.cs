using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Interfaces
{
    public interface IRepositorioProvaPresenca
    {
        Task<bool> ExisteProvaPresencaPorNomeEAno(string nomeProva, int anoProva);
        Task<IEnumerable<ListarProvaPresencaDto>> ObterTodasAsync();
        Task<ListarProvaPresencaDto> ObterPorIdAsync(long id);
    }
}