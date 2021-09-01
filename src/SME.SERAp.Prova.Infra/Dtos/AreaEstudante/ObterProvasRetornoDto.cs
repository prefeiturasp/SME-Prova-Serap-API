using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterProvasRetornoDto
    {
        public ObterProvasRetornoDto(string descricao, int itensQuantidade, DateTime dataInicio, DateTime? dataFim, long id)
        {
            Id = id;
            Descricao = descricao;
            ItensQuantidade = itensQuantidade;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public long Id { get; set; }
        public string Descricao { get; set; }
        public int ItensQuantidade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}

