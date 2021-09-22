using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaAlunoUseCase
    {
        Task<ProvaAlunoDto> Executar(long provaId);
    }
}
