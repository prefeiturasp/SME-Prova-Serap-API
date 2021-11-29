using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCadernoAlunoPorProvaIdRaQuery : IRequest<string>
    {
        public ObterCadernoAlunoPorProvaIdRaQuery(long provaId, long alunoRA)
        {
            ProvaId = provaId;
            AlunoRA = alunoRA;
        }

        public long ProvaId { get; set; }
        public long AlunoRA { get; set; }
    }
}
