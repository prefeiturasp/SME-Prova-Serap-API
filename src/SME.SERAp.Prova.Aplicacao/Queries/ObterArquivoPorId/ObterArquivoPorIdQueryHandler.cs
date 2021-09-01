using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoPorIdQueryHandler : IRequestHandler<ObterArquivoPorIdQuery, Arquivo>
    {
        private readonly IRepositorioArquivo repositorioArquivo;

        public ObterArquivoPorIdQueryHandler(IRepositorioArquivo repositorioArquivo)
        {
            this.repositorioArquivo = repositorioArquivo ?? throw new System.ArgumentNullException(nameof(repositorioArquivo));
        }
        public async Task<Arquivo> Handle(ObterArquivoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioArquivo.ObterPorIdAsync(request.Id);
        }
    }
}
