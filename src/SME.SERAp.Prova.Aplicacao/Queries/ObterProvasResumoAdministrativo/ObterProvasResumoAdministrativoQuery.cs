using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasResumoAdministrativoQuery : IRequest<IEnumerable<QuestaoDetalheRetornoDto>>
    {
        public ObterProvasResumoAdministrativoQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
