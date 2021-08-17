using MediatR;
using SME.SERAp.Prova.Dados;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorAnoQueryHandler : IRequestHandler<ObterProvasPorAnoQuery, IEnumerable<Dominio.Prova>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvasPorAnoQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<IEnumerable<Dominio.Prova>> Handle(ObterProvasPorAnoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterPorAnoData(request.Ano, request.DataReferenia);
        }
    }
}
