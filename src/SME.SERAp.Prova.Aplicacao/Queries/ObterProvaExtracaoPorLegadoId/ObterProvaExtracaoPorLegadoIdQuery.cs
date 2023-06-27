using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaExtracaoPorLegadoIdQuery : IRequest<ProvaExtracaoDto>
    {
        public ObterProvaExtracaoPorLegadoIdQuery(long provaLegadoId)
        {
            ProvaLegadoId = provaLegadoId;
        }

        public long ProvaLegadoId { get; set; }
    }
}
