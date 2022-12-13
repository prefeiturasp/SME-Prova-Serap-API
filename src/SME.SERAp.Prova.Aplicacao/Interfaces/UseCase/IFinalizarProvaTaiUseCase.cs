using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IFinalizarProvaTaiUseCase
    {
        public Task<bool> Executar(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto);
    }
}
