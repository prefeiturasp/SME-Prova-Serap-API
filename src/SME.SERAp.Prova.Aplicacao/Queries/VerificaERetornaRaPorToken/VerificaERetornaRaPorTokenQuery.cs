using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaERetornaRaPorTokenQuery : IRequest<long>
    {
        public VerificaERetornaRaPorTokenQuery(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
