namespace SME.SERAp.Prova.Infra
{
    public class QuestaoCompletaResultadoDto : DtoBase
    {
        public QuestaoCompletaResultadoDto()
        {

        }

        public QuestaoCompletaDto Questao { get; set; }
        public long? OrdemAlternativaCorreta { get; set; }
        public long? OrdemAlternativaResposta { get; set; }
        public string RespostaConstruida { get; set; }
    }
}
