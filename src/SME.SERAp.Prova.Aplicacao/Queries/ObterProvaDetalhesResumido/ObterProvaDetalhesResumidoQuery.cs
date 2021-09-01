using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesResumidoQuery : IRequest<IEnumerable<ProvaDetalheResumidoBaseDadosDto>>
    {
        public ObterProvaDetalhesResumidoQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
