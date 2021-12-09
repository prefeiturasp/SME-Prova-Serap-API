using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorProvaIdsRaQueryHandler : IRequestHandler<ObterProvaAlunoPorProvaIdsRaQuery, IEnumerable<ProvaAluno>>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;

        public ObterProvaAlunoPorProvaIdsRaQueryHandler(IRepositorioProvaAluno repositorioProvaAluno)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
        }
        public async Task<IEnumerable<ProvaAluno>> Handle(ObterProvaAlunoPorProvaIdsRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProvaAluno.ObterPorProvaIdsRaAsync(request.ProvaIds, request.AlunoRa);
        }
    }
}
