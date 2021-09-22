using System;

namespace SME.SERAp.Prova.Dominio
{
    public class Alternativa : EntidadeBase
    {
        public Alternativa()
        {

        }
        public int Ordem { get; set; }
        public string Numeracao { get; set; }
        public string Descricao { get; set; }
        public long QuestaoId { get; set; }


        public Alternativa(int ordem,
            string alternativa, string descricao, long questaoId)
        {
            Ordem = ordem;
            Numeracao = alternativa;
            Descricao = descricao;
            QuestaoId = questaoId;
        }
    }
}