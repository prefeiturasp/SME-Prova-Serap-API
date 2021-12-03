using System.Collections.Generic;

namespace SME.SERAp.Prova.Dominio
{
    public class Questao : EntidadeBase
    {
        public int Ordem { get; set; }
        public string TextoBase { get; set; }
        public string Enunciado { get; set; }
        public long QuestaoLegadoId { get; set; }
        public long ProvaId { get; set; }
        public QuestaoTipo Tipo { get; set; }
        public string Caderno { get; set; }
        public int QuantidadeAlternativas { get; set; }
        public List<Alternativa> Alternativas { get; set; }



        public Questao()
        {
            Alternativas = new List<Alternativa>();
        }

        public Questao(string textoBase, long questaoLegadoId, string enunciado, int ordem, long provaId, QuestaoTipo tipo, string caderno, int quantidadeAlternativas)
        {
            Ordem = ordem;
            TextoBase = textoBase;
            Enunciado = enunciado;
            QuestaoLegadoId = questaoLegadoId;
            ProvaId = provaId;
            Tipo = tipo;
            Caderno = caderno;
            QuantidadeAlternativas = quantidadeAlternativas;
            Alternativas = new List<Alternativa>();
        }
    }
}