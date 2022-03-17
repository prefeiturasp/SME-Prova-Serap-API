using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IAutenticarUsuarioAdmUseCase
    {
        Task<string> Executar(AutenticacaoAdmDto autenticacaoDto);
    }
}
