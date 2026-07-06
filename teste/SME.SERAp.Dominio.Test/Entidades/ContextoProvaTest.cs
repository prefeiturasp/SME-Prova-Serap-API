using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class ContextoProvaTest
    {
        [Fact]
        public void Deve_Criar_ContextoProva_Com_Construtor_Padrao()
        {
            var contexto = new ContextoProva
            {
                ProvaId = 1,
                Ordem = 2,
                Titulo = "Título Teste",
                Imagem = "imagem.png",
                Texto = "Texto do contexto",
                Posicionamento = Posicionamento.Centro
            };

            Assert.Equal(1, contexto.ProvaId);
            Assert.Equal(2, contexto.Ordem);
            Assert.Equal("Título Teste", contexto.Titulo);
            Assert.Equal("imagem.png", contexto.Imagem);
            Assert.Equal("Texto do contexto", contexto.Texto);
            Assert.Equal(Posicionamento.Centro, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Construtor_Parametros()
        {
            var contexto = new ContextoProva(10, 3, "Título", "img.jpg", "Texto", Posicionamento.Direita);

            Assert.Equal(10, contexto.ProvaId);
            Assert.Equal(3, contexto.Ordem);
            Assert.Equal("Título", contexto.Titulo);
            Assert.Equal("img.jpg", contexto.Imagem);
            Assert.Equal("Texto", contexto.Texto);
            Assert.Equal(Posicionamento.Direita, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Posicionamento_NaoCadastrado()
        {
            var contexto = new ContextoProva(1, 1, "T", "I", "Txt", Posicionamento.NaoCadastrado);

            Assert.Equal(Posicionamento.NaoCadastrado, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Posicionamento_Esquerda()
        {
            var contexto = new ContextoProva(1, 1, "T", "I", "Txt", Posicionamento.Esquerda);

            Assert.Equal(Posicionamento.Esquerda, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Posicionamento_Centro()
        {
            var contexto = new ContextoProva(1, 1, "T", "I", "Txt", Posicionamento.Centro);

            Assert.Equal(Posicionamento.Centro, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Posicionamento_Direita()
        {
            var contexto = new ContextoProva(1, 1, "T", "I", "Txt", Posicionamento.Direita);

            Assert.Equal(Posicionamento.Direita, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Titulo_Nulo()
        {
            var contexto = new ContextoProva(1, 1, null, "img", "txt", Posicionamento.Centro);

            Assert.Null(contexto.Titulo);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Imagem_Nula()
        {
            var contexto = new ContextoProva(1, 1, "Titulo", null, "txt", Posicionamento.Centro);

            Assert.Null(contexto.Imagem);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Texto_Nulo()
        {
            var contexto = new ContextoProva(1, 1, "Titulo", "img", null, Posicionamento.Centro);

            Assert.Null(contexto.Texto);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Via_Construtor_Padrao_Com_Valores_Default()
        {
            var contexto = new ContextoProva();

            Assert.Equal(0, contexto.ProvaId);
            Assert.Equal(0, contexto.Ordem);
            Assert.Null(contexto.Titulo);
            Assert.Null(contexto.Imagem);
            Assert.Null(contexto.Texto);
            Assert.Equal(Posicionamento.NaoCadastrado, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var contexto = new ContextoProva();
            contexto.ProvaId = 55;
            contexto.Ordem = 4;
            contexto.Titulo = "Novo Título";
            contexto.Imagem = "nova.png";
            contexto.Texto = "Novo texto";
            contexto.Posicionamento = Posicionamento.Esquerda;

            Assert.Equal(55, contexto.ProvaId);
            Assert.Equal(4, contexto.Ordem);
            Assert.Equal("Novo Título", contexto.Titulo);
            Assert.Equal("nova.png", contexto.Imagem);
            Assert.Equal("Novo texto", contexto.Texto);
            Assert.Equal(Posicionamento.Esquerda, contexto.Posicionamento);
        }

        [Fact]
        public void Deve_Verificar_Todos_Os_Valores_Do_Enum_Posicionamento()
        {
            var valores = System.Enum.GetValues(typeof(Posicionamento));

            Assert.Contains(Posicionamento.NaoCadastrado, (Posicionamento[])valores);
            Assert.Contains(Posicionamento.Direita, (Posicionamento[])valores);
            Assert.Contains(Posicionamento.Centro, (Posicionamento[])valores);
            Assert.Contains(Posicionamento.Esquerda, (Posicionamento[])valores);
            Assert.Equal(4, valores.Length);
        }

        [Fact]
        public void Deve_Verificar_Valores_Numericos_Do_Enum_Posicionamento()
        {
            Assert.Equal(0, (int)Posicionamento.NaoCadastrado);
            Assert.Equal(1, (int)Posicionamento.Direita);
            Assert.Equal(2, (int)Posicionamento.Centro);
            Assert.Equal(3, (int)Posicionamento.Esquerda);
        }

        [Fact]
        public void Deve_Herdar_De_EntidadeBase()
        {
            var contexto = new ContextoProva();

            Assert.IsAssignableFrom<EntidadeBase>(contexto);
        }

        [Fact]
        public void Deve_Criar_ContextoProva_Com_Ordem_Zero()
        {
            var contexto = new ContextoProva(1, 0, "T", "I", "Txt", Posicionamento.Centro);

            Assert.Equal(0, contexto.Ordem);
        }
    }
}