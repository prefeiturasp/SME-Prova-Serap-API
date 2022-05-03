using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterContextoResumoPorProvaIdQuery : IRequest<IEnumerable<ContextoResumoProvaDto>>
    {
        public ObterContextoResumoPorProvaIdQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
