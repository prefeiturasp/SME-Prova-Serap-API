using SME.SERAp.Prova.Infra.Dtos;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterProvaAreaAdministrativoUseCase
    {
        Task<PaginacaoResultadoDto<Dominio.Prova>> Executar(ProvaAdmFiltroDto paginacaoFiltroDto);
    }
}
