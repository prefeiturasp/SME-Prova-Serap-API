namespace SME.SERAp.Prova.Infra.Dtos.Questao
{
    public class QuestaoTaiDto : DtoBase
    {
        public long Id { get; set; }
        public int Ordem { get; set; }
        public decimal Discriminacao { get; set; }
        public decimal ProporcaoAcertos { get; set; }
        public decimal AcertoCasual { get; set; }
    }
}
