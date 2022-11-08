using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterProvasRetornoDto : DtoBase
    {
        public ObterProvasRetornoDto(string descricao, int itensQuantidade,int status, DateTime? dataInicioDownload, DateTime dataInicio, DateTime? dataFim, long id, int tempoExecucao, 
            int tempoExtra, int tempoAlerta, int tempoTotal, DateTime? dataInicioProvaAluno, string senha, Modalidade modalidade, DateTime? dataFimProvaAluno, 
            int? quantidadeRespostaSincronizacao, DateTime ultimaAlteracao, string caderno, bool provaComProficiencia = false, bool apresentarResultados = false, 
            bool apresentarResultadosPorItem = false)
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
            DataFimProvaAluno = dataFimProvaAluno;
            QuantidadeRespostaSincronizacao = quantidadeRespostaSincronizacao;
            UltimaAlteracao = ultimaAlteracao;
            Caderno = caderno;
            ProvaComProficiencia = provaComProficiencia;
            ApresentarResultados = apresentarResultados;
            ApresentarResultadosPorItem = apresentarResultadosPorItem;
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
        public DateTime? DataFimProvaAluno { get; set; }
        public Modalidade Modalidade { get; set; }
        public int? QuantidadeRespostaSincronizacao { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        public string Caderno { get; set; }
        public bool ProvaComProficiencia { get; set; }
        public bool ApresentarResultados { get; set; }
        public bool ApresentarResultadosPorItem { get; set; }
    }
}

