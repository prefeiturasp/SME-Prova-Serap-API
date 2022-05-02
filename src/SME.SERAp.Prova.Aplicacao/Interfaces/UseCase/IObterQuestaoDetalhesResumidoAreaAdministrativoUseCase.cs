using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterQuestaoDetalhesResumidoAreaAdministrativoUseCase
    {
        Task<QuestaoDetalheResumoRetornoDto> Executar(long provaId, long questaoId);
    }
}
