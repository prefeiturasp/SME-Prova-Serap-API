using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProficienciaFinalPorProvaQuery : IRequest<decimal>
    {
        public ObterProficienciaFinalPorProvaQuery(long alunoRa, long provaId)
        {
            AlunoRa = alunoRa;
            ProvaId = provaId;
        }

        public long AlunoRa { get; set; }
        public long ProvaId { get; set; }
    }
}
