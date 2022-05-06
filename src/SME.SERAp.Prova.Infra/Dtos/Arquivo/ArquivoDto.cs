namespace SME.SERAp.Prova.Infra
{
    public class ArquivoDto : DtoBase
    {
        public long QuestaoId { get; set; }
        public long Id { get; set; }
        public string Caminho { get; set; }
        public long TamanhoBytes { get; set; }
    }
}
