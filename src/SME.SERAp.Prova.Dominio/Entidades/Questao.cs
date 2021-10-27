namespace SME.SERAp.Prova.Dominio
{
    public class Questao : EntidadeBase
    {
        public int Ordem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public long QuestaoLegadoId { get; set; }
        public long ProvaId { get; set; }
        public QuestaoTipo Tipo { get; set; }
        public string Caderno { get; set; }



        public Questao()
        {
        }

        public Questao(string titulo, long questaoLegadoId, string descricao, int ordem, long provaId, QuestaoTipo tipo, string caderno)
        {
            Ordem = ordem;
            Titulo = titulo;
            Descricao = descricao;
            QuestaoLegadoId = questaoLegadoId;
            ProvaId = provaId;
            Tipo = tipo;
            Caderno = caderno;
        }
    }
}