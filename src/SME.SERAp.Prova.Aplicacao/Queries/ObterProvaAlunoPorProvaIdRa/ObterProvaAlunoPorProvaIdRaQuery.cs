using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorProvaIdRaQuery : IRequest<ProvaAluno>
    {
        public ObterProvaAlunoPorProvaIdRaQuery(long provaId, long alunoRa)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
    }
}
