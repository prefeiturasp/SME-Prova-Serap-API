using MediatR;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterProvaPresencaPorId
{
    public class ObterProvaPresencaPorIdQueryHandler : IRequestHandler<ObterProvaPresencaPorIdQuery, ListarProvaPresencaDto>
    {
        private readonly IRepositorioProvaPresenca repositorioProvaPresenca;

        public ObterProvaPresencaPorIdQueryHandler(IRepositorioProvaPresenca repositorioProvaPresenca)
        {
            this.repositorioProvaPresenca = repositorioProvaPresenca;
        }

        public async Task<ListarProvaPresencaDto> Handle(ObterProvaPresencaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProvaPresenca.ObterPorIdAsync(request.Id);
        }
    }
}