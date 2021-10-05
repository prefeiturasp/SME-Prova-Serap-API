using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterProvasRetornoDto
    {
        public ObterProvasRetornoDto(string descricao, int itensQuantidade,int status, DateTime dataInicio, DateTime? dataFim, long id, int tempoExecucao, int tempoExtra, int tempoTotal)
        {
            Id = id;
            Descricao = descricao;
            ItensQuantidade = itensQuantidade;
            TempoExecucao = tempoExecucao;
            TempoExtra = tempoExtra;
            TempoTotal = tempoTotal;
            Status = status;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public long Id { get; set; }
        public string Descricao { get; set; }
        public int ItensQuantidade { get; set; }
        public int TempoExecucao { get; set; }
        public int TempoExtra { get; set; }
        public int TempoTotal { get; set; }        
        public int Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}

