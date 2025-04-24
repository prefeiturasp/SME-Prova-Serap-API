using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries
{
    public class ObterIdsQuestoesPorProvaIdCadernoQueryHandler : IRequestHandler<ObterIdsQuestoesPorProvaIdCadernoQuery, IEnumerable<long>>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterIdsQuestoesPorProvaIdCadernoQueryHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<IEnumerable<long>> Handle(ObterIdsQuestoesPorProvaIdCadernoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.ObterIdsQuestoesPorProvaIdCadernoAsync(request.ProvaId, request.Caderno);
        }
    }
}
