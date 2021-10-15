using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirAlunoCommand : IRequest<bool>
    {
        public IncluirAlunoCommand(long ra, string nome)
        {
            RA = ra;
            Nome = nome;
        }

        public long RA { get; set; }
        public string Nome { get; set; }
    }
}
