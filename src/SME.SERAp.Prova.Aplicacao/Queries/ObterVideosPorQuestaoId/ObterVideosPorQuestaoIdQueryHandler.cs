using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterVideosPorQuestaoIdQueryHandler : IRequestHandler<ObterVideosPorQuestaoIdQuery, IEnumerable<QuestaoVideo>>
    {

        private readonly IRepositorioQuestaoVideo repositorioQuestaoVideo;

        public ObterVideosPorQuestaoIdQueryHandler(IRepositorioQuestaoVideo repositorioQuestaoVideo)
        {
            this.repositorioQuestaoVideo = repositorioQuestaoVideo ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoVideo));
        }

        public async Task<IEnumerable<QuestaoVideo>> Handle(ObterVideosPorQuestaoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoVideo.ObterPorQuestaoId(request.QuestaoId);
        }
    }
}
