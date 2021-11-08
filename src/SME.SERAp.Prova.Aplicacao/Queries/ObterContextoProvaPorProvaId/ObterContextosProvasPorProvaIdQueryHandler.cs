using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterContextosProvasPorProvaIdQueryHandler : IRequestHandler<ObterContextosProvasPorProvaIdQuery, IEnumerable<ContextoProva>>
    {
        private readonly IRepositorioContextoProva repositorioContextoProva;

        public ObterContextosProvasPorProvaIdQueryHandler(IRepositorioContextoProva repositorioContextoProva)
        {
            this.repositorioContextoProva = repositorioContextoProva ?? throw new System.ArgumentNullException(nameof(repositorioContextoProva));
        }
        public async Task<IEnumerable<ContextoProva>> Handle(ObterContextosProvasPorProvaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioContextoProva.ObterContextoProvaPorProvaId(request.ProvaId);
        }
    }
}
