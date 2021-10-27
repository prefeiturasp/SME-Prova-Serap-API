using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class OObterProvaDetalhesResumidoBIBQueryHandler : IRequestHandler<ObterProvaDetalhesResumidoBIBQuery, IEnumerable<ProvaDetalheResumidoBaseDadosDto>>
    {
        private readonly IRepositorioProva repositorioProva;

        public OObterProvaDetalhesResumidoBIBQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> Handle(ObterProvaDetalhesResumidoBIBQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterDetalhesResumoBIBPorIdERaAsync(request.ProvaId, request.AlunoRA);
        }
    }
}
