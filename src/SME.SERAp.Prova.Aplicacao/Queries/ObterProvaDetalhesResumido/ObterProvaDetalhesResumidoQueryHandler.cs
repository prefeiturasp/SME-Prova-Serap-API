using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesResumidoQueryHandler : IRequestHandler<ObterProvaDetalhesResumidoQuery, IEnumerable<ProvaDetalheResumidoBaseDadosDto>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvaDetalhesResumidoQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> Handle(ObterProvaDetalhesResumidoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterDetalhesResumoPorIdAsync(request.ProvaId);
        }
    }
}
