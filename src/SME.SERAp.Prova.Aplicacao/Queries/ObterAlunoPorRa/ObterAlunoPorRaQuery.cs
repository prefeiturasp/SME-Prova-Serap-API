using FluentValidation;
using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoPorRaQuery : IRequest<Aluno>
    {
        public ObterAlunoPorRaQuery(long alunoRA)
        {
            AlunoRA = alunoRA;
        }

        public long AlunoRA { get; set; }
    }
}
