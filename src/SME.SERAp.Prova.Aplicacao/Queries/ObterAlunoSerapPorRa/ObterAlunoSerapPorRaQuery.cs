using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoSerapPorRaQuery : IRequest<Aluno>
    {
        public ObterAlunoSerapPorRaQuery(long alunoRA)
        {
            AlunoRA = alunoRA;
        }
        public long AlunoRA { get; set; }
    }
}
