using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaPorIdQuery : IRequest<Dominio.Prova>
    {
        public ObterProvaPorIdQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
