using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTurmasAlunoPorRaQuery : IRequest<IEnumerable<Turma>>
    {
        public ObterTurmasAlunoPorRaQuery(long alunoRa)
        {
            AlunoRa = alunoRa;
        }

        public long AlunoRa { get; set; }
    }
}
