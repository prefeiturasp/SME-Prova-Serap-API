namespace SME.SERAp.Prova.Infra.Dtos.ApiR
{
    public class ObterProximoItemApiRRespostaDto
    {
        public long ProximaQuestao { get; set; }
        public int NumeroRespostas { get; set; }
        public int Ordem { get; set; }
        public decimal ParA { get; set; }
        public decimal ParB { get; set; }
        public decimal ParC { get; set; }
        public decimal Proficiencia { get; set; }
        public decimal ErroMedida { get; set; }
    }
}
