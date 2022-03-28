using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IRevalidaTokenJwtAdmUseCase
    {
        public Task<UsuarioAutenticacaoDto> Executar(RevalidaTokenDto revalidaTokenDto);
    }
}
