using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaERetornaInformacoesPorTokenQuery : IRequest<InformacoesTokenDto>
    {
        public VerificaERetornaInformacoesPorTokenQuery(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
