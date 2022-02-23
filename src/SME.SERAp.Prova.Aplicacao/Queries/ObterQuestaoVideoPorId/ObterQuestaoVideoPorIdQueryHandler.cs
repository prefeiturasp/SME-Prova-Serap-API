using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoVideoPorIdQueryHandler : IRequestHandler<ObterQuestaoVideoPorIdQuery, QuestaoVideo>
    {

        private readonly IRepositorioQuestaoVideo repositorioQuestaoVideo;

        public ObterQuestaoVideoPorIdQueryHandler(IRepositorioQuestaoVideo repositorioQuestaoVideo)
        {
            this.repositorioQuestaoVideo = repositorioQuestaoVideo ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoVideo));
        }

        public async Task<QuestaoVideo> Handle(ObterQuestaoVideoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoVideo.ObterPorIdAsync(request.Id);
        }
    }
}
