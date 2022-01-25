using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoAudioPorIdQueryHandler : IRequestHandler<ObterArquivoAudioPorIdQuery, ArquivoRetornoDto>
    {

        private readonly IRepositorioArquivo repositorioArquivo;
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterArquivoAudioPorIdQueryHandler(IRepositorioArquivo repositorioArquivo, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioArquivo = repositorioArquivo ?? throw new System.ArgumentNullException(nameof(repositorioArquivo));
            this.repositorioQuestao = repositorioQuestao ?? throw new System.ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<ArquivoRetornoDto> Handle(ObterArquivoAudioPorIdQuery request, CancellationToken cancellationToken)
        {
            var arquivo = await repositorioArquivo.ObterPorIdAsync(request.Id);
            if (arquivo == null)
                return null;

            var questao = await repositorioQuestao.ObterPorArquivoAudioIdAsync(arquivo.Id);
            var arquivoAudio = new ArquivoRetornoDto(arquivo.Id, arquivo.Caminho);
            arquivoAudio.QuestaoId = questao.Id;

            return arquivoAudio;
        }
    }
}
