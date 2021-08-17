using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterProvasRetornoDto
    {
        public ObterProvasRetornoDto(string descricao, int itensQuantidade, DateTime dataInicio, DateTime? dataFim)
        {
            Descricao = descricao;
            ItensQuantidade = itensQuantidade;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public string Descricao { get; set; }
        public int ItensQuantidade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}

