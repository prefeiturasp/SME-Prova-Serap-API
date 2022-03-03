using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoIdPorArquivoIdQueryHandler : IRequestHandler<ObterQuestaoIdPorArquivoIdQuery, long>
    {

        private readonly IRepositorioQuestaoArquivo repositorioQuestaoArquivo;
        private readonly IRepositorioQuestao repositorioQuestao;
        private readonly IRepositorioQuestaoVideo repositorioQuestaoVideo;

        public ObterQuestaoIdPorArquivoIdQueryHandler(IRepositorioQuestaoArquivo repositorioQuestaoArquivo, IRepositorioQuestao repositorioQuestao,
            IRepositorioQuestaoVideo repositorioQuestaoVideo)
        {
            this.repositorioQuestaoArquivo = repositorioQuestaoArquivo ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoArquivo));
            this.repositorioQuestao = repositorioQuestao ?? throw new System.ArgumentNullException(nameof(repositorioQuestao));
            this.repositorioQuestaoVideo = repositorioQuestaoVideo ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoVideo));
        }

        public async Task<long> Handle(ObterQuestaoIdPorArquivoIdQuery request, CancellationToken cancellationToken)
        {
            var questaoArquivo = await repositorioQuestaoArquivo.ObterPorArquivoIdAsync(request.ArquivoId);
            if (questaoArquivo != null)
                return questaoArquivo.QuestaoId;

            var questaoAudio = await repositorioQuestao.ObterPorArquivoAudioIdAsync(request.ArquivoId);
            if (questaoAudio != null)
                return questaoAudio.Id;

            var questaoVideo = await repositorioQuestaoVideo.ObterPorArquivoId(request.ArquivoId);
            if (questaoVideo != null)
                return questaoVideo.QuestaoId;

            return 0;
        }
    }
}
