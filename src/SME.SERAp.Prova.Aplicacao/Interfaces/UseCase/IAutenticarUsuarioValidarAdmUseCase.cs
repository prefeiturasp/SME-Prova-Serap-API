using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IAutenticarUsuarioValidarAdmUseCase
    {
        Task<UsuarioAutenticacaoDto> Executar(AutenticacaoValidarAdmDto autenticacaoValidarAdmDto);
    }
}
