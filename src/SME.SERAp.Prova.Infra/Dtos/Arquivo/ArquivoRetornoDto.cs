namespace SME.SERAp.Prova.Infra
{
    public class ArquivoRetornoDto : DtoBase
    {
        public ArquivoRetornoDto()
        {
        }

        public ArquivoRetornoDto(long id, string caminho)
        {
            Id = id;
            LegadoId = id;
            Caminho = caminho;
        }

        public ArquivoRetornoDto(long id, string caminho, long questaoId)
        {
            Id = id;
            LegadoId = id;
            Caminho = caminho;
            QuestaoId = questaoId;
        }

        public long Id { get; set; }
        public long LegadoId { get; set; }
        public string Caminho { get; set; }
        public long QuestaoId { get; set; }
    }
}