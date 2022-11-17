using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaResultadoResumoQuery : IRequest<IEnumerable<ProvaResultadoResumoDto>>
    {
        public ObterProvaResultadoResumoQuery(long provaId, int caderno, long alunoRa)
        {
            ProvaId = provaId;
            Caderno = caderno;
            AlunoRa = alunoRa;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
        public int Caderno { get; set; }

    }
}
