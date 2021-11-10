using System;

namespace SME.SERAp.Prova.Dominio
{
    public class ContextoProva : EntidadeBase
    {
        public ContextoProva()
        {

        }
        public long ProvaId { get; set; }
        public int Ordem { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public Posicionamento Posicionamento { get; set; }
        public string Texto { get; set; }


        public ContextoProva(long provaId,
            int ordem, string titulo, string imagem, string texto, Posicionamento posicionamento)
        {
            ProvaId = provaId;
            Ordem = ordem;
            Titulo = titulo;
            Imagem = imagem;
            Texto = texto;
            Posicionamento = posicionamento;
        }
    }
}