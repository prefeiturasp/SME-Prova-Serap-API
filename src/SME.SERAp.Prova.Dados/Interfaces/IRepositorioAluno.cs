using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAluno : IRepositorioBase<Aluno>
    {
        Task<Aluno> ObterPorRA(long ra);
    }
}
