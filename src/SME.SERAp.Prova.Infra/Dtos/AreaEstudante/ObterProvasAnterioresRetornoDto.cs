using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    public class ObterProvasAnterioresRetornoDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public int ItensQuantidade { get; set; }
        public int TempoTotal { get; set; }
        public int Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataInicioProvaAluno { get; set; }
        public DateTime? DataFimProvaAluno { get; set; }

    }
}

