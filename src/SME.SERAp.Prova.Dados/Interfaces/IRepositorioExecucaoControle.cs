using SME.SERAp.Prova.Dominio;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioExecucaoControle : IRepositorioBase<ExecucaoControle>
    {
        Task<ExecucaoControle> ObterUltimaExecucaoPorTipoAsync(ExecucaoControleTipo execucaoControleTipo);
    }
}