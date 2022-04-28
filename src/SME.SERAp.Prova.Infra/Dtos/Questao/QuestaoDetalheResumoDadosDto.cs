namespace SME.SERAp.Prova.Infra.Dtos
{
    public class QuestaoDetalheResumoDadosDto : DtoBase
    {
        public long QuestaoId { get; set; }
        public long AlternativaId { get; set; }
        public long QuestaoArquivoId { get; set; }
        public long AlternativaArquivoId { get; set; }
        public long VideoId { get; set; }
        public long AudioId { get; set; }
    }
}
