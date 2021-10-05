namespace SME.SERAp.Prova.Dominio
{
    public class Questao : EntidadeBase
    {
        public int Ordem { get; set; }
        public string Pergunta { get; set; }
        public string Enunciado { get; set; }
        public long QuestaoLegadoId { get; set; }
        public long ProvaId { get; set; }
        public QuestaoTipo Tipo { get; set; }



        public Questao()
        {
        }

        public Questao(string pergunta, long questaoLegadoId, string enunciado, int ordem, long provaId, QuestaoTipo tipo)
        {
            Ordem = ordem;
            Pergunta = pergunta;
            Enunciado = enunciado;
            QuestaoLegadoId = questaoLegadoId;
            ProvaId = provaId;
            Tipo = tipo;
        }
    }
}