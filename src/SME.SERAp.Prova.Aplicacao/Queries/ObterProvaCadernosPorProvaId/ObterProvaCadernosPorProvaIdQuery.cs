using MediatR;
using SME.SERAp.Prova.Infra.Dtos;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterProvaCadernosPorProvaId
{
    public class ObterProvaCadernosPorProvaIdQuery : IRequest<IEnumerable<ProvaCadernoDadoDto>>
    {
        public ObterProvaCadernosPorProvaIdQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
