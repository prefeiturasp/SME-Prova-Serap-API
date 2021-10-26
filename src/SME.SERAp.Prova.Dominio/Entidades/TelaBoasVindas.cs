using System;

namespace SME.SERAp.Prova.Dominio
{
    public class TelaBoasVindas : EntidadeBase
    {
        public int Ordem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }

        public TelaBoasVindas()
        {
        }
        public TelaBoasVindas(string titulo, string descricao, string imagem, int ordem, bool ativo)
        {
            Ordem = ordem;
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Ativo = ativo;
        }
    }
}