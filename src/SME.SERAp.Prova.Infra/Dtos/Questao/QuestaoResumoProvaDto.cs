namespace SME.SERAp.Prova.Infra
{
    public class QuestaoResumoProvaDto : DtoBase
    {
        public long ProvaId { get; set; }
        public long QuestaoId { get; set; }
        public long QuestaoLegadoId { get; set; }
        public string Caderno { get; set; }
        public int Ordem { get; set; }
    }
}
