namespace SME.SERAp.Prova.Infra
{
    public class ArquivoRetornoDto
    {
        public ArquivoRetornoDto(long id, string caminho, long questaoId)
        {
            Id = id;
            Caminho = caminho;
            QuestaoId = questaoId;
        }
        public long Id { get; set; }
        public string Caminho { get; set; }
        public long QuestaoId { get; set; }
    }
}
