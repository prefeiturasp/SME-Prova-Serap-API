using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioTurma : IRepositorioBase<Turma>
    {
        Task<IEnumerable<Turma>> ObterTurmasAlunoPorRaAsync(long alunoRa);
    }
}
