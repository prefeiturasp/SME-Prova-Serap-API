using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioLogadoInformacaoPorClaimQuery : IRequest<string>
    {
        public ObterUsuarioLogadoInformacaoPorClaimQuery(string claim)
        {
            Claim = claim;
        }

        public string Claim { get; set; }
    }
}
