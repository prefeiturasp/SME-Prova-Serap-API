using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra
{
    public class AlternativaDto : DtoBase
    {
        public long QuestaoId { get; set; }
        public long Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public string Numeracao { get; set; }
    }
}
