using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorProvaIdRaStatusQuery : IRequest<ProvaAluno>
    {
        public ObterProvaAlunoPorProvaIdRaStatusQuery(long provaId, long alunoRa, int status)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
            Status = status;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
        public int Status { get; set; }
    }
}
