using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra.Dtos.ProvaPresenca
{
    public class ListarProvaPresencaDto
    {
        public long Id { get; set; }
        public string NomeProva { get; set; }
        public int AnoProva { get; set; }
        public string DescricaoProva { get; set; }
        public DateTime DataInicialAplicacao { get; set; }
        public DateTime DataFinalAplicacao { get; set; }
        public DateTime? DataCorte { get; set; }
        public bool VinculaAlunoCadernoExtra { get; set; }
        public DateTime DataProcessamento { get; set; }
        public List<long> TurmasIds { get; set; }
    }
}