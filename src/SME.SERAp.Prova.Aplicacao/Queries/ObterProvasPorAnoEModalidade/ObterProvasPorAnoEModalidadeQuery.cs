using MediatR;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorAnoEModalidadeQuery : IRequest<IEnumerable<Dominio.Prova>>
    {
        public ObterProvasPorAnoEModalidadeQuery(string ano, DateTime dataReferenia, int modalidade)
        {
            Ano = ano;
            DataReferenia = dataReferenia;
            Modalidade = modalidade;
        }

        public string Ano { get; set; }
        public DateTime DataReferenia { get; set; }
        public int Modalidade { get; set; }
    }
}
