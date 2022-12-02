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
        public int TipoQuestao { get; set; }
        public string AlternativaAluno { get; set; }
        public string AlternativaCorreta { get; set; }
        public bool Correta { get; set; }
        public bool RespostaConstruidaRespondida { get; set; }
    }
}