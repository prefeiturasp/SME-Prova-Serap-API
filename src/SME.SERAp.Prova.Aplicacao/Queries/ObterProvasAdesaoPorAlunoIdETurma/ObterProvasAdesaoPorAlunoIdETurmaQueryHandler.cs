using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAdesaoPorAlunoIdETurmaQueryHandler : IRequestHandler<ObterProvasAdesaoPorAlunoIdETurmaQuery, List<ProvaAnoDto>>
    {

        private readonly IRepositorioProva repositorioProva;

        public ObterProvasAdesaoPorAlunoIdETurmaQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }

        public async Task<List<ProvaAnoDto>> Handle(ObterProvasAdesaoPorAlunoIdETurmaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterProvasAdesaoAlunoAsync(request.AlunoId, request.TurmaId);
        }
    }
}
