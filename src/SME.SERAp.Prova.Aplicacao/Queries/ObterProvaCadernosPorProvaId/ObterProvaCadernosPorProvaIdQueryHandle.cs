using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra.Dtos.Prova;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterProvaCadernosPorProvaId
{
    public class ObterProvaCadernosPorProvaIdQueryHandle : IRequestHandler<ObterProvaCadernosPorProvaIdQuery, IEnumerable<ProvaCadernoDadoDto>>
    {
        public readonly IRepositorioQuestao repositorioQuestao;

        public ObterProvaCadernosPorProvaIdQueryHandle(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new System.ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<IEnumerable<ProvaCadernoDadoDto>> Handle(ObterProvaCadernosPorProvaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.ObterCadernosPorProvaId(request.ProvaId);
        }
    }
}
