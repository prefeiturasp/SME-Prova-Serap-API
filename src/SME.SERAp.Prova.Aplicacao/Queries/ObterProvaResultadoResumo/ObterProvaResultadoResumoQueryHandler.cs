using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaResultadoResumoQueryHandler : IRequestHandler<ObterProvaResultadoResumoQuery, IEnumerable<ProvaResultadoResumoDto>>
    {

        private readonly IRepositorioProva repositorioProva;

        public ObterProvaResultadoResumoQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }

        public async Task<IEnumerable<ProvaResultadoResumoDto>> Handle(ObterProvaResultadoResumoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterResultadoResumoProvaAsync(request.ProvaId, request.AlunoRa);
        }
    }
}
