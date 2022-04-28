namespace SME.SERAp.Prova.Infra
{
    public class TelaBoasVindasDto : DtoBase
    {
        public TelaBoasVindasDto(long id, string titulo, string descricao, string imagem, int ordem)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Ordem = ordem;
        }

        public long Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
    }
}
