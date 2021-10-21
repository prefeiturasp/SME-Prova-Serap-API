using System;

namespace SME.SERAp.Prova.Dominio
{
    public class QuestaoAlunoResposta : EntidadeBase
    {
        public QuestaoAlunoResposta()
        {
            CriadoEm = DateTime.Now;
        }

        public QuestaoAlunoResposta(long questaoId, long alunoRa, long? alternativaId, string resposta, DateTime criadoEm, int tempoRespostaAluno, int visualizacoes)
        {
            QuestaoId = questaoId;
            AlunoRa = alunoRa;
            AlternativaId = alternativaId;
            Resposta = resposta;
            CriadoEm = criadoEm;
            TempoRespostaAluno = tempoRespostaAluno;
            Visualizacoes = visualizacoes;
        }

        public long QuestaoId { get; set; }
        public long AlunoRa { get; set; }
        public long? AlternativaId { get; set; }
        public string Resposta { get; set; }
        public int Visualizacoes { get; set; }
        public DateTime CriadoEm { get; set; }
        public int TempoRespostaAluno { get; set; }
    }
}
