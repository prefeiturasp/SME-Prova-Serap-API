using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterContextoProvaPorIdQuery : IRequest<ContextoProva>
    {
        public ObterContextoProvaPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
