using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioAluno : IRepositorioBase<Aluno>
    {
        Task<AlunoDetalheDto> ObterAlunoDetalhePorRa(long ra);
        Task<Aluno> ObterPorRA(long ra);
    }
}
