using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaDetalheCompletoBaseDadosDto
    {
        public long QuestaoId { get; set; }
        public string QuestaoTextoBase { get; set; }
        public string QuestaoEnunciado { get; set; }
        public int QuestaoOrdem { get; set; }
        public QuestaoTipo QuestaoTipo { get; set; }
        public string QuestaoCaderno { get; set; }
        public int QuestaoQuantidadeAlternativas { get; set; }
        public long AlternativaId { get; set; }
        public string AlternativaDescricao { get; set; }
        public int AlternativaOrdem { get; set; }
        public string AlternativaNumeracao { get; set; }
        public long AlternativaQuestaoId { get; set; }
        public long ArquivoId { get; set; }
        public string ArquivoCaminho { get; set; }
        public long ArquivoLegadoId { get; set; }
        public long ArquivoTamanho { get; set; }
    }
}
