using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api
{
    public interface IStartupTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
