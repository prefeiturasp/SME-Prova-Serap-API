using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTokenJwtQuery : IRequest<string>
    {
        public ObterTokenJwtQuery(long alunoRA)
        {
            AlunoRA = alunoRA;
        }

        public long AlunoRA { get; set; }
    }
}
