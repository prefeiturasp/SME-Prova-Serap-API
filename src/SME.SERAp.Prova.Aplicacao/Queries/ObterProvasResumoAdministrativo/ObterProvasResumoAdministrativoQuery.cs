using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasResumoAdministrativoQuery : IRequest<IEnumerable<ProvaResumoAdministrativoRetornoDto>>
    {
        public ObterProvasResumoAdministrativoQuery(long provaId, string caderno)
        {
            ProvaId = provaId;
            Caderno = caderno;
        }

        public long ProvaId { get; set; }
        public string Caderno { get; set; }
    }
}
