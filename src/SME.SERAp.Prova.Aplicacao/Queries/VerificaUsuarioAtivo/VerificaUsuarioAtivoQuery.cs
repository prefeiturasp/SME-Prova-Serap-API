using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaUsuarioAtivoQuery : IRequest<bool>
    {
        public VerificaUsuarioAtivoQuery(long alunoRA)
        {
            AlunoRA = alunoRA;
        }

        public long AlunoRA { get; set; }
    }
}
