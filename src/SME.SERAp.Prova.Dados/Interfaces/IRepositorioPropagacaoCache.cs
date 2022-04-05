using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioPropagacaoCache
    {
        Task<IEnumerable<Dominio.Prova>> ObterTodasProvasParaCacheAsync();
        Task<IEnumerable<Dominio.Questao>> ObterTodasQuestoesParaCacheAsync();
        Task<IEnumerable<Dominio.Alternativa>> ObterTodasAlternativasParaCacheAsync();
        Task<IEnumerable<Dominio.Arquivo>> ObterTodosArquivosParaCacheAsync();
    }
}
