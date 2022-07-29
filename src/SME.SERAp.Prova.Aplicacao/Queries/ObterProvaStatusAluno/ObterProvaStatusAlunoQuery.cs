using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
   public class ObterProvaStatusAlunoQuery : IRequest<ProvaAlunoDto>
    {
        public ObterProvaStatusAlunoQuery(long provaId, long alunoRa)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
    }
}
