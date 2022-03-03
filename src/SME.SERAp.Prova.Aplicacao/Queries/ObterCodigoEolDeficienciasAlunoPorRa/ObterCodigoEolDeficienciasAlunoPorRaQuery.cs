using MediatR;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCodigoEolDeficienciasAlunoPorRaQuery : IRequest<List<int>>
    {
        public ObterCodigoEolDeficienciasAlunoPorRaQuery(long alunoRa)
        {
            AlunoRa = alunoRa;
        }

        public long AlunoRa { get; set; }
    }
}
