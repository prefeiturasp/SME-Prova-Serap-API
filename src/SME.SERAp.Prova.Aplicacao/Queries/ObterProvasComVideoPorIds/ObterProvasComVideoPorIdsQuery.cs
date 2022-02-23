using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasComVideoPorIdsQuery : IRequest<long[]>
    {
        public ObterProvasComVideoPorIdsQuery(long[] ids)
        {
            Ids = ids;
        }

        public long[] Ids { get; set; }
    }
}
