using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAdesaoPorAlunoRaETurmaQueryHandler : IRequestHandler<ObterProvasAdesaoPorAlunoRaETurmaQuery, List<ProvaAnoDto>>
    {

        private readonly IRepositorioProva repositorioProva;

        public ObterProvasAdesaoPorAlunoRaETurmaQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }

        public async Task<List<ProvaAnoDto>> Handle(ObterProvasAdesaoPorAlunoRaETurmaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterProvasAdesaoAlunoAsync(request.AlunoRa, request.TurmaId);
        }
    }
}
