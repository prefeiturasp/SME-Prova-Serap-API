using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaProvaExistePorSerapIdQuery : IRequest<bool>
    {
        public VerificaProvaExistePorSerapIdQuery(long provaId)
        {
            ProvaId = provaId;
        }

        public long ProvaId { get; set; }
    }
}
