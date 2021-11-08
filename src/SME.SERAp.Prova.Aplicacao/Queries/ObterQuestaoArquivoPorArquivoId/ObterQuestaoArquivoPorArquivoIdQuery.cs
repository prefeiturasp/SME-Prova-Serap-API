using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoArquivoPorArquivoIdQuery : IRequest<QuestaoArquivo>
    {
        public ObterQuestaoArquivoPorArquivoIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
