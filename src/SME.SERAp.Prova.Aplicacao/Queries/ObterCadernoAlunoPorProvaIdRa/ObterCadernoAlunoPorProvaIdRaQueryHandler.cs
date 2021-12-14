using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCadernoAlunoPorProvaIdRaQueryHandler : IRequestHandler<ObterCadernoAlunoPorProvaIdRaQuery, string>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterCadernoAlunoPorProvaIdRaQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<string> Handle(ObterCadernoAlunoPorProvaIdRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.ObterCadernoAlunoPorProvaIdRa(request.ProvaId, request.AlunoRA);
        }
    }
}
