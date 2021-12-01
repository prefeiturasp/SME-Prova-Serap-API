using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterDetalhesAlunoCacheQuery : IRequest<MeusDadosRetornoDto>
    {
        public ObterDetalhesAlunoCacheQuery(long alunoRa)
        {
            AlunoRA = alunoRa;
        }

        public long AlunoRA { get; set; }
    }
}
