using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaExtracaoPorLegadoIdQueryHandler : IRequestHandler<ObterProvaExtracaoPorLegadoIdQuery, ProvaExtracaoDto>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvaExtracaoPorLegadoIdQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<ProvaExtracaoDto> Handle(ObterProvaExtracaoPorLegadoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterProvaExtracaoPorLegadoId(request.ProvaLegadoId);
        }
    }
}
