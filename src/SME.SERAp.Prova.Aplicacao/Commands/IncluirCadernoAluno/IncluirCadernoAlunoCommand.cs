using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirCadernoAlunoCommand : IRequest<bool>
    {
        public IncluirCadernoAlunoCommand(long ra, long alunoId, long provaId, string caderno)
        {
            Ra = ra;
            AlunoId = alunoId;
            ProvaId = provaId;
            Caderno = caderno;
        }

        public long Ra { get; set; }
        public long AlunoId { get; set; }
        public long ProvaId { get; set; }
        public string Caderno { get; set; }
    }
}
