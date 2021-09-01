using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlternativaPorIdQueryHandler : IRequestHandler<ObterAlternativaPorIdQuery, Alternativa>
    {
        private readonly IRepositorioAlternativa repositorioAlternativa;

        public ObterAlternativaPorIdQueryHandler(IRepositorioAlternativa repositorioAlternativa)
        {
            this.repositorioAlternativa = repositorioAlternativa ?? throw new System.ArgumentNullException(nameof(repositorioAlternativa));
        }
        public async Task<Alternativa> Handle(ObterAlternativaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlternativa.ObterPorIdAsync(request.Id);
        }
    }
}
