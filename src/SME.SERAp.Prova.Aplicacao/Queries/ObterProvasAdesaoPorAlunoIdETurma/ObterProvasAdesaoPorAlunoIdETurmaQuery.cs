using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAdesaoPorAlunoIdETurmaQuery : IRequest<List<ProvaAnoDto>>
    {
        public ObterProvasAdesaoPorAlunoIdETurmaQuery(long alunoId, long turmaId)
        {
            AlunoId = alunoId;
            TurmaId = turmaId;
        }

        public long AlunoId { get; set; }
        public long TurmaId { get; set; }
    }
}
