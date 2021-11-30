using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaDetalhesCompletoBIBQuery : IRequest<IEnumerable<ProvaDetalheCompletoBaseDadosDto>>
    {
        public ObterProvaDetalhesCompletoBIBQuery(long provaId, long alunoRA)
        {
            ProvaId = provaId;
            AlunoRA = alunoRA;
        }

        public long ProvaId { get; set; }
        public long AlunoRA { get; set; }
    }
}
