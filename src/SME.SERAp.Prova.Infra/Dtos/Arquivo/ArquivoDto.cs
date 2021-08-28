namespace SME.SERAp.Prova.Infra
{
    public class ArquivoDto
    {
        public ArquivoDto(string nome, string caminho, long? id = null)
        {
            Id = id.Value;
            Nome = nome;
            Caminho = caminho;
        }
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
    }
}
