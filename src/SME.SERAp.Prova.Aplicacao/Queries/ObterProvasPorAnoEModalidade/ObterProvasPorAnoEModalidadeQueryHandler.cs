using MediatR;
using SME.SERAp.Prova.Dados;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorAnoEModalidadeQueryHandler : IRequestHandler<ObterProvasPorAnoEModalidadeQuery, IEnumerable<Dominio.Prova>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvasPorAnoEModalidadeQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<IEnumerable<Dominio.Prova>> Handle(ObterProvasPorAnoEModalidadeQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterPorAnoDataEModalidade(request.Ano, request.DataReferenia, request.Modalidade);
        }
    }
}
