﻿using MediatR;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasPorAnoEModalidadeQuery : IRequest<IEnumerable<Dominio.Prova>>
    {
        public ObterProvasPorAnoEModalidadeQuery(int ano, DateTime dataReferenia, int modalidade)
        {
            Ano = ano;
            DataReferenia = dataReferenia;
            Modalidade = modalidade;
        }

        public int Ano { get; set; }
        public DateTime DataReferenia { get; set; }
        public int Modalidade { get; set; }
    }
}