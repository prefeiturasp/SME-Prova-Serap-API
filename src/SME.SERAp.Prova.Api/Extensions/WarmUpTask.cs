using Microsoft.Extensions.DependencyInjection;
using SME.SERAp.Prova.Aplicacao;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api
{
    public class WarmUpCacheTask : IStartupTask
    {
        private readonly IServiceProvider serviceProvider;
        
        public WarmUpCacheTask(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = serviceProvider.CreateScope();
            var propagacaoCacheUseCase = scope.ServiceProvider.GetRequiredService<IPropagacaoCacheUseCase>();
            await propagacaoCacheUseCase.Propagar();
        }
    }
}
