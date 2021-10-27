using MediatR;
using SME.SERAp.Prova.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaPorIdQueryHandler : IRequestHandler<ObterProvaPorIdQuery, Dominio.Prova>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvaPorIdQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<Dominio.Prova> Handle(ObterProvaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterPorIdAsync(request.ProvaId);
        }
    }
}
