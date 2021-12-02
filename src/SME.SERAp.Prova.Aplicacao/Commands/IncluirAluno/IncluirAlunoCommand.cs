using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirAlunoCommand : IRequest<bool>
    {
        public IncluirAlunoCommand(long ra, string nome, long turmaId)
        {
            RA = ra;
            Nome = nome;
            TurmaId = turmaId;
        }

        public long RA { get; set; }
        public long TurmaId { get; set; }
        public string Nome { get; set; }
    }
}
