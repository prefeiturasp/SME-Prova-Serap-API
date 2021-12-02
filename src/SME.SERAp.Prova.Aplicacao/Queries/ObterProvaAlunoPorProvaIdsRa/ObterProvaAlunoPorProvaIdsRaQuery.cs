using MediatR;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaAlunoPorProvaIdsRaQuery : IRequest<IEnumerable<ProvaAluno>>
    {
        public ObterProvaAlunoPorProvaIdsRaQuery(long[] provaIds, long alunoRa)
        {
            ProvaIds = provaIds;
            AlunoRa = alunoRa;
        }

        public long[] ProvaIds { get; set; }
        public long AlunoRa { get; set; }
    }
}
