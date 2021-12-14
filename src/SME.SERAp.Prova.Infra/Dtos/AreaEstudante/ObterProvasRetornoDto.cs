using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterProvasRetornoDto
    {
        public ObterProvasRetornoDto(string descricao, int itensQuantidade,int status, DateTime? dataInicioDownload, DateTime dataInicio, DateTime? dataFim, long id, int tempoExecucao, 
            int tempoExtra, int tempoAlerta, int tempoTotal, DateTime? dataInicioProvaAluno, string senha, Modalidade modalidade)
        {
            Id = id;
            Descricao = descricao;
            ItensQuantidade = itensQuantidade;
            TempoExecucao = tempoExecucao;
            TempoExtra = tempoExtra;
            TempoAlerta = tempoAlerta;
            TempoTotal = tempoTotal;
            Senha = senha;
            Status = status;
            DataInicioDownload = dataInicioDownload;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataInicioProvaAluno = dataInicioProvaAluno;
            Modalidade = modalidade;
        }

        public long Id { get; set; }
        public string Descricao { get; set; }
        public int ItensQuantidade { get; set; }
        public int TempoExecucao { get; set; }
        public int TempoExtra { get; set; }
        public string Senha { get; }
        public int TempoAlerta { get; set; }
        public int TempoTotal { get; set; }        
        public int Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataInicioDownload { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataInicioProvaAluno { get; set; }
        public Modalidade Modalidade { get; set; }

    }
}

