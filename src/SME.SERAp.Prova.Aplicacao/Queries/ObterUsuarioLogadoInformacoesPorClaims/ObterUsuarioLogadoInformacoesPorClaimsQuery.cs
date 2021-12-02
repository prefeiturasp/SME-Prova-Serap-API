using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioLogadoInformacoesPorClaimsQuery : IRequest<IEnumerable<ParametroDto>>
    {
        public ObterUsuarioLogadoInformacoesPorClaimsQuery(string[] claims)
        {
            Claims = claims;
        }

        public string[] Claims { get; set; }
    }
}
