using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra
{
    public class QuestaoResumoProvaDto : DtoBase
    {
        public long ProvaId { get; set; }
        public long QuestaoId { get; set; }
        public long QuestaoLegadoId { get; set; }
        public string Caderno { get; set; }
        public IEnumerable<AlternativaResumoProvaDto> Alternativas { get; set; }
        public int Ordem { get; set; }
    }

    public class AlternativaResumoProvaDto
    {
        public long QuestaoId { get; set; }
        public long AlternativaId { get; set; }
        public long AlternativaLegadoId { get; set; }
        public int Ordem { get; set; }
    }
}
