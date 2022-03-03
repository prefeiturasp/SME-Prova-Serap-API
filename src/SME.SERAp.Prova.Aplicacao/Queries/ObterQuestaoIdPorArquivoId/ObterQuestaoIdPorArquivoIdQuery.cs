using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoIdPorArquivoIdQuery : IRequest<long>
    {
        public ObterQuestaoIdPorArquivoIdQuery(long arquivoId)
        {
            ArquivoId = arquivoId;
        }

        public long ArquivoId { get; set; }

    }
}
