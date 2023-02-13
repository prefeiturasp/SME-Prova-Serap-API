using System.Text.Json.Serialization;

namespace SME.SERAp.Prova.Infra.Dtos.ApiR
{
    public class ObterProximaQuestaoTaiDto
    {
        [JsonPropertyName("ESTUDANTE")]
        public string Estudante { get; set; }
        [JsonPropertyName("AnoEscolarEstudante")]
        public string AnoEscolarEstudante { get; set; }
        [JsonPropertyName("proficiencia")]
        public string Proficiencia { get; set; }
        [JsonPropertyName("profic.inic")]
        public string ProficienciaInicial { get; set; }
        [JsonPropertyName("idItem")]
        public string IdItem { get; set; }
        [JsonPropertyName("parA")]
        public string ParA { get; set; }
        [JsonPropertyName("parB")]
        public string ParB { get; set; }
        [JsonPropertyName("parC")]
        public string ParC { get; set; }
        [JsonPropertyName("anoEscolarItem")]
        public string AnoEscolarItem { get; set; }
        [JsonPropertyName("habilidade")]
        public string Habilidade { get; set; }
        [JsonPropertyName("assunto")]
        public string Assunto { get; set; }
        [JsonPropertyName("subAssunto")]
        public string SubAssunto { get; set; }
        [JsonPropertyName("administrado")]
        public string Administrado { get; set; }
        [JsonPropertyName("respostas")]
        public string Respostas { get; set; }
        [JsonPropertyName("gabarito")]
        public string Gabarito { get; set; }
        [JsonPropertyName("erropadrao")]
        public string Erropadrao { get; set; }

        [JsonPropertyName("n.Ij")]
        public int NIj { get; set; }

    }
}
