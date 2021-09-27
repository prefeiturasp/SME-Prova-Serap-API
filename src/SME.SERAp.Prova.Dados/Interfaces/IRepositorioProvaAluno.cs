using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioProvaAluno : IRepositorioBase<ProvaAluno>
    {
        Task<ProvaAluno> ObterPorProvaIdRaAsync(long provaId, long alunoRa);
        Task<ProvaAluno> ObterPorProvaIdRaStatusAsync(long provaId, long alunoRa, int status);
    }
}
