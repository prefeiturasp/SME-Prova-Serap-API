using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class ContextoProvaDto : DtoBase
    {
        public ContextoProvaDto(long id, long provaId, string titulo, string texto, string imagem, Posicionamento posicionamento, int ordem)
        {
            Id = id;
            ProvaId = provaId;
            Titulo = titulo;
            Texto = texto;
            Imagem = imagem;
            Posicionamento = posicionamento;
            Ordem = ordem;
        }

        public long ProvaId { get; set; }
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public int Ordem { get; set; }
        public Posicionamento Posicionamento { get; set; }
    }
}
