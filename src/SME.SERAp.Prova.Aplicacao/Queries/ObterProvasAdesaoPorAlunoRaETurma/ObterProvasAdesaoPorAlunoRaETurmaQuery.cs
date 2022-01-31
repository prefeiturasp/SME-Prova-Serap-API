using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAdesaoPorAlunoRaETurmaQuery : IRequest<List<ProvaAnoDto>>
    {
        public ObterProvasAdesaoPorAlunoRaETurmaQuery(long alunoRa, long turmaId)
        {
            AlunoRa = alunoRa;
            TurmaId = turmaId;
        }

        public long AlunoRa { get; set; }
        public long TurmaId { get; set; }
    }
}
