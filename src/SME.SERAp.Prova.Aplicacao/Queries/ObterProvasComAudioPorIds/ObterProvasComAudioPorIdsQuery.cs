using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasComAudioPorIdsQuery : IRequest<long[]>
    {

        public ObterProvasComAudioPorIdsQuery(long[] ids)
        {
            Ids = ids;
        }

        public long[] Ids { get; set; }
    }
}
