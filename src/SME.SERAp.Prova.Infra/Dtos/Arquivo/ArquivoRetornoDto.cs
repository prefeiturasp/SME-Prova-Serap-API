namespace SME.SERAp.Prova.Infra
{
    public class ArquivoRetornoDto
    {
        public ArquivoRetornoDto(long id, string caminho)
        {
            Id = id;
            Caminho = caminho;
        }
        public long Id { get; set; }
        public string Caminho { get; set; }
    }
}
