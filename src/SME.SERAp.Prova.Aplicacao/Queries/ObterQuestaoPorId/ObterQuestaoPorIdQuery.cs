using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoPorIdQuery : IRequest<Questao>
    {
        public ObterQuestaoPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
