
namespace SME.SERAp.Prova.Infra
{
    public class ArquivoVideoResponseDto
    {
        public ArquivoVideoResponseDto()
        {

        }

        public ArquivoVideoResponseDto(long id, string caminho, string caminhoVideoConvertido, string caminhoVideoThumbinail, long questaoId)
        {
            Id = id;
            Caminho = caminho;
            CaminhoVideoConvertido = caminhoVideoConvertido;
            CaminhoVideoThumbinail = caminhoVideoThumbinail;
            QuestaoId = questaoId;
        }

        public long Id { get; set; }
        public string Caminho { get; set; }
        public string CaminhoVideoConvertido { get; set; }
        public string CaminhoVideoThumbinail { get; set; }
        public long QuestaoId { get; set; }

    }
}
