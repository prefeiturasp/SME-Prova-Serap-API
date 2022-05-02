namespace SME.SERAp.Prova.Infra
{
    public class AlternativaDetalheRetornoDto : DtoBase
    {
        public AlternativaDetalheRetornoDto(long id, string descricao, int ordem, string numeracao, long questaoId)
        {
            Id = id;
            Descricao = descricao;
            Ordem = ordem;
            Numeracao = numeracao;
            QuestaoId = questaoId;
        }

        public long Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public string Numeracao { get; set; }
        public long QuestaoId { get; set; }
    }
}
