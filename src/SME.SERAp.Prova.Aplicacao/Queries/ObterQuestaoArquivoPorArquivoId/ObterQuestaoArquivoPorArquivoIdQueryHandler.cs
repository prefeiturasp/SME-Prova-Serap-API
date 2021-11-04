using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoArquivoPorArquivoIdQueryHandler : IRequestHandler<ObterQuestaoArquivoPorArquivoIdQuery, QuestaoArquivo>
    {
        private readonly IRepositorioQuestaoArquivo repositorioQuestaoArquivo;

        public ObterQuestaoArquivoPorArquivoIdQueryHandler(IRepositorioQuestaoArquivo repositorioQuestaoArquivo)
        {
            this.repositorioQuestaoArquivo = repositorioQuestaoArquivo ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoArquivo));
        }
        public async Task<QuestaoArquivo> Handle(ObterQuestaoArquivoPorArquivoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoArquivo.ObterPorArquivoIdAsync(request.Id);
        }
    }
}
