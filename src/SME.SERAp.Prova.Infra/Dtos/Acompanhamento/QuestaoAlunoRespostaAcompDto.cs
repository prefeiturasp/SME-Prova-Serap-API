
namespace SME.SERAp.Prova.Infra
{
    public class QuestaoAlunoRespostaAcompDto
    {

        public QuestaoAlunoRespostaAcompDto()
        {

        }

        public QuestaoAlunoRespostaAcompDto(long provaId, long alunoRa, long questaoId, long? alternativaId, int? tempo)
        {
            ProvaId = provaId;
            AlunoRa = alunoRa;
            QuestaoId = questaoId;
            AlternativaId = alternativaId;
            Tempo = tempo;
            Consolidar = true;
        }

        public long ProvaId { get; set; }
        public long AlunoRa { get; set; }
        public long QuestaoId { get; set; }
        public long? AlternativaId { get; set; }
        public int? Tempo { get; set; }
        public bool Consolidar { get; set; } = true;
    }
}
