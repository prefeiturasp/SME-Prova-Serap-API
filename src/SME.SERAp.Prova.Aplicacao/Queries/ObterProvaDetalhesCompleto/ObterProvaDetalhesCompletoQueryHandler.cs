using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesCompletoQueryHandler : IRequestHandler<ObterProvaDetalhesCompletoQuery, IEnumerable<ProvaDetalheCompletoBaseDadosDto>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvaDetalhesCompletoQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<IEnumerable<ProvaDetalheCompletoBaseDadosDto>> Handle(ObterProvaDetalhesCompletoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterDetalhesCompletoPorIdAsync(request.ProvaId);
        }
    }
}
