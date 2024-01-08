using System;

namespace SME.SERAp.Prova.Dominio
{
    public class QuestaoAlunoAdministrado : EntidadeBase
    {
        public QuestaoAlunoAdministrado()
        {
            CriadoEm = DateTime.Now;
        }

        public QuestaoAlunoAdministrado(long questaoId, long alunoId, int ordem) : this()
        {
            QuestaoId = questaoId;
            AlunoId = alunoId;
            Ordem = ordem;
        }

        public long QuestaoId { get; set; }
        public long AlunoId { get; set; }
        public int Ordem { get; set; }
        public DateTime CriadoEm { get; set; }        
    }
}