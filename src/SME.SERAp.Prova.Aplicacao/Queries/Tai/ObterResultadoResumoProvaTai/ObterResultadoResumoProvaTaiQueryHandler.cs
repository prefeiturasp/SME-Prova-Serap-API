using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterResultadoResumoProvaTaiQueryHandler : IRequestHandler<ObterResultadoResumoProvaTaiQuery, IEnumerable<ProvaTaiResultadoDto>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterResultadoResumoProvaTaiQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }

        public async Task<IEnumerable<ProvaTaiResultadoDto>> Handle(ObterResultadoResumoProvaTaiQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterResultadoResumoProvaTaiAsync(request.ProvaId, request.AlunoRa);
        }
    }
}
