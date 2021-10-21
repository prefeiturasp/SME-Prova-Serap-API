using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlternativaPorIdQuery : IRequest<Alternativa>
    {
        public ObterAlternativaPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
