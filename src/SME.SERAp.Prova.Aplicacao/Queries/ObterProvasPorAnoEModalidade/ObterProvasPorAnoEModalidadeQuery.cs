using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorAnoEModalidadeQuery : IRequest<IEnumerable<ProvaAnoDto>>
    {
        public ObterProvasPorAnoEModalidadeQuery(string ano, int modalidade)
        {
            Ano = ano;
            Modalidade = modalidade;
        }

        public string Ano { get; set; }
        public int Modalidade { get; set; }
    }
}
