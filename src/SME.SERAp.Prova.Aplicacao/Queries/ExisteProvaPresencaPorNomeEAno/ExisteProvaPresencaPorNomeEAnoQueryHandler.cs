using MediatR;
using SME.SERAp.Prova.Dados.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries.ExisteProvaPresencaPorNomeEAno
{
    public class ExisteProvaPresencaPorNomeEAnoQueryHandler : IRequestHandler<ExisteProvaPresencaPorNomeEAnoQuery, bool>
    {
        private readonly IRepositorioProvaPresenca repositorioProvaPresenca;

        public ExisteProvaPresencaPorNomeEAnoQueryHandler(IRepositorioProvaPresenca repositorioProvaPresenca)
        {
            this.repositorioProvaPresenca = repositorioProvaPresenca;
        }

        public async Task<bool> Handle(ExisteProvaPresencaPorNomeEAnoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProvaPresenca.ExisteProvaPresencaPorNomeEAno(request.NomeProva, request.AnoProva);
        }
    }
}