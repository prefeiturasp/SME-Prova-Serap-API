using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesCompletoBIBQueryHandler : IRequestHandler<ObterProvaDetalhesCompletoBIBQuery, IEnumerable<ProvaDetalheCompletoBaseDadosDto>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvaDetalhesCompletoBIBQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<IEnumerable<ProvaDetalheCompletoBaseDadosDto>> Handle(ObterProvaDetalhesCompletoBIBQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterDetalhesCompletoBIBPorIdERaAsync(request.ProvaId, request.AlunoRA);
        }
    }
}
