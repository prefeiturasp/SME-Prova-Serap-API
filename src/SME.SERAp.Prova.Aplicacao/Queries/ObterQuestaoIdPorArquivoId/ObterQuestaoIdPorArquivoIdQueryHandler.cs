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

        public ObterQuestaoIdPorArquivoIdQueryHandler(IRepositorioQuestaoArquivo repositorioQuestaoArquivo)
        {
            this.repositorioQuestaoArquivo = repositorioQuestaoArquivo ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoArquivo));
        }

        public async Task<long> Handle(ObterQuestaoIdPorArquivoIdQuery request, CancellationToken cancellationToken)
        {
            //return await repositorioQuestaoArquivo.ObterPorArquivoIdAsync(request.Id);
        }
    }
}
