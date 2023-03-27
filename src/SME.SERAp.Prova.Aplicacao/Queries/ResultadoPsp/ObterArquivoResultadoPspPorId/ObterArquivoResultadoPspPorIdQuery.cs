using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoResultadoPspPorIdQuery : IRequest<ArquivoResultadoPspDto>
    {
        public ObterArquivoResultadoPspPorIdQuery(long id)
        {
            Id = id;
        }
        public long Id { get; set; }
    }
}