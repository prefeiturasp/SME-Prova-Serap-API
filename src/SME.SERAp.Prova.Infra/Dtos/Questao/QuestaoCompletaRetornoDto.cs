namespace SME.SERAp.Prova.Infra
{
    public class QuestaoCompletaRetornoDto
    {
        public QuestaoCompletaRetornoDto(long id, string titulo, string descricao, int ordem, int tipo, int quantidadeAlternativas)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Ordem = ordem;
            Tipo = tipo;
            QuantidadeAlternativas = quantidadeAlternativas;
        }

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public int Tipo { get; set; }
        public int QuantidadeAlternativas { get; set; }

    }
}
