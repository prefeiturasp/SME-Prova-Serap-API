using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorDeficienciaQuery : IRequest<long[]>
    {
        public ObterProvasPorDeficienciaQuery(long[] provasId, int[] deficiencias)
        {
            ProvasId = provasId;
            Deficiencias = deficiencias;
        }

        public long[] ProvasId { get; set; }
        public int[] Deficiencias { get; set; }
    }
}
