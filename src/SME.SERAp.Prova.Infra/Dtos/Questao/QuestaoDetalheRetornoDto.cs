namespace SME.SERAp.Prova.Infra
{
    public class QuestaoDetalheRetornoDto
    {
        public QuestaoDetalheRetornoDto(long id, string titulo, string descricao, int ordem, int tipo)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Ordem = ordem;
            Tipo = tipo;
        }

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public int Tipo { get; set; }

    }
}
