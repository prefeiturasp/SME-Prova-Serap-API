using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaERetornaInformacoesPorTokenAdmQuery : IRequest<InformacoesTokenAdmDto>
    {
        public VerificaERetornaInformacoesPorTokenAdmQuery(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
