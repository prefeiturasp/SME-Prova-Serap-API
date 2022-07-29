using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirCadernoAlunoCommand : IRequest<bool>
    {
        public IncluirCadernoAlunoCommand(long alunoId, long provaId, string caderno)
        {
            AlunoId = alunoId;
            ProvaId = provaId;
            Caderno = caderno;
        }

        public long AlunoId { get; set; }
        public long ProvaId { get; set; }
        public string Caderno { get; set; }
    }
}
