namespace SME.SERAp.Prova.Infra
{
    public class QuestaoCompletaResultadoDto : DtoBase
    {
        public QuestaoCompletaResultadoDto()
        {

        }

        public string Questao { get; set; }
        public long AlternativaCorretaId { get; set; }
        public long AlternativaRespostaId { get; set; }

    }
}
