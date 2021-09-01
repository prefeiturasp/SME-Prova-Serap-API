namespace SME.SERAp.Prova.Infra
{
    public class QuestaoDetalheRetornoDto
    {
        public QuestaoDetalheRetornoDto(long id, string titulo, string descricao, int ordem)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Ordem = ordem;
        }

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }

    }
}
