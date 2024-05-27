using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaResultadoResumoQuery : IRequest<IEnumerable<ProvaResultadoResumoDto>>
    {
        public ObterProvaResultadoResumoQuery(long provaId, long alunoRa, string caderno = null)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
            Caderno = caderno;
        }

        public long ProvaId { get; }
        public long AlunoRa { get; }
        public string Caderno { get; }
    }
}
