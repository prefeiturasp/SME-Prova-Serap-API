using MediatR;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorAnoQuery : IRequest<IEnumerable<Dominio.Prova>>
    {
        public ObterProvasPorAnoQuery(int ano, DateTime dataReferenia)
        {
            Ano = ano;
            DataReferenia = dataReferenia;
        }

        public int Ano { get; set; }
        public DateTime DataReferenia { get; set; }
    }
}
