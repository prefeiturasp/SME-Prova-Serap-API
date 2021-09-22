﻿using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterProvasRetornoDto
    {
        public ObterProvasRetornoDto(string descricao, int itensQuantidade,int status, DateTime dataInicio, DateTime? dataFim, long id)
        {
            Id = id;
            Descricao = descricao;
            ItensQuantidade = itensQuantidade;
            Status = status;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public long Id { get; set; }
        public string Descricao { get; set; }
        public int ItensQuantidade { get; set; }
        public int Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}

