namespace SME.SERAp.Prova.Infra
{
    public class ArquivoDto : DtoBase
    {
        public long Id { get; set; }
        public long LegadoId { get; set; }
        public long QuestaoId { get; set; }
        public string Caminho { get; set; }
        public long TamanhoBytes { get; set; }
    }
}
