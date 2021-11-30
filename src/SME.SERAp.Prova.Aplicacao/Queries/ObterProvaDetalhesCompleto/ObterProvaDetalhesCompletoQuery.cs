using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesCompletoQuery : IRequest<IEnumerable<ProvaDetalheCompletoBaseDadosDto>>
    {
        public ObterProvaDetalhesCompletoQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
