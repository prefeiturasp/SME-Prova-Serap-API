using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaProficienciaPorProvaQuery : IRequest<decimal>
    {
        public ObterUltimaProficienciaPorProvaQuery(long provaId, long alunoRa)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
    }
}
