using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoPorIdLegadoQueryHandler : IRequestHandler<ObterArquivoPorIdLegadoQuery, Arquivo>
    {
        private readonly IRepositorioArquivo repositorioArquivo;
        private readonly IRepositorioCache repositorioCache;

        public ObterArquivoPorIdLegadoQueryHandler(IRepositorioArquivo repositorioArquivo, IRepositorioCache repositorioCache)
        {
            this.repositorioArquivo = repositorioArquivo ?? throw new System.ArgumentNullException(nameof(repositorioArquivo));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<Arquivo> Handle(ObterArquivoPorIdLegadoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterAsync($"ar-{request.Id}", async () => await repositorioArquivo.ObterPorIdLegadoAsync(request.Id));
        }
    }
}
