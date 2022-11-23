namespace SME.SERAp.Prova.Infra
{
    public class ProvaResultadoResumoDto : DtoBase
    {
        public ProvaResultadoResumoDto()
        {

        }

        public long IdQuestaoLegado { get; set; }
        public string DescricaoQuestao { get; set; }
        public int OrdemQuestao { get; set; }
        public string AlternativaAluno { get; set; }
        public bool AlternativaCorreta { get; set; }
        public decimal? Proficiencia { get; set; }
    }
}