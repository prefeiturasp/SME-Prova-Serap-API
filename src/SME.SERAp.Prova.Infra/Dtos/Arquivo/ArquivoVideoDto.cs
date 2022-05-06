namespace SME.SERAp.Prova.Infra
{
    public class ArquivoVideoDto : DtoBase
    {
        public long QuestaoId { get; set; }
        public long Id { get; set; }
        public string Caminho { get; set; }
        public long TamanhoBytes { get; set; }
        public string CaminhoVideoConvertido { get; set; }
        public long VideoConvertidoTamanhoBytes { get; set; }
        public string CaminhoVideoThumbinail { get; set; }
        public long VideoThumbinailTamanhoBytes { get; set; }
    }
}
