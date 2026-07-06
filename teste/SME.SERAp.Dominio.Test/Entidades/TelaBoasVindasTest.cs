using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class TelaBoasVindasTest
    {
        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Construtor_Parametros()
        {
            var tela = new TelaBoasVindas("Título", "Descrição", "imagem.png", 1, true);

            Assert.Equal("Título", tela.Titulo);
            Assert.Equal("Descrição", tela.Descricao);
            Assert.Equal("imagem.png", tela.Imagem);
            Assert.Equal(1, tela.Ordem);
            Assert.True(tela.Ativo);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Construtor_Padrao()
        {
            var tela = new TelaBoasVindas
            {
                Titulo = "Bem-vindo",
                Descricao = "Texto de boas-vindas",
                Imagem = "foto.jpg",
                Ordem = 2,
                Ativo = false
            };

            Assert.Equal("Bem-vindo", tela.Titulo);
            Assert.Equal("Texto de boas-vindas", tela.Descricao);
            Assert.Equal("foto.jpg", tela.Imagem);
            Assert.Equal(2, tela.Ordem);
            Assert.False(tela.Ativo);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Valores_Default()
        {
            var tela = new TelaBoasVindas();

            Assert.Equal(0, tela.Ordem);
            Assert.Null(tela.Titulo);
            Assert.Null(tela.Descricao);
            Assert.Null(tela.Imagem);
            Assert.False(tela.Ativo);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Ativo_True()
        {
            var tela = new TelaBoasVindas("T", "D", "I", 1, true);

            Assert.True(tela.Ativo);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Ativo_False()
        {
            var tela = new TelaBoasVindas("T", "D", "I", 1, false);

            Assert.False(tela.Ativo);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Titulo_Nulo()
        {
            var tela = new TelaBoasVindas(null, "D", "I", 1, true);

            Assert.Null(tela.Titulo);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Descricao_Nula()
        {
            var tela = new TelaBoasVindas("T", null, "I", 1, true);

            Assert.Null(tela.Descricao);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Imagem_Nula()
        {
            var tela = new TelaBoasVindas("T", "D", null, 1, true);

            Assert.Null(tela.Imagem);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Com_Ordem_Zero()
        {
            var tela = new TelaBoasVindas("T", "D", "I", 0, true);

            Assert.Equal(0, tela.Ordem);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var tela = new TelaBoasVindas("Original", "Desc", "img", 1, true);
            tela.Titulo = "Alterado";
            tela.Ordem = 5;
            tela.Ativo = false;

            Assert.Equal("Alterado", tela.Titulo);
            Assert.Equal(5, tela.Ordem);
            Assert.False(tela.Ativo);
        }

        [Fact]
        public void Deve_Criar_TelaBoasVindas_Herdando_EntidadeBase()
        {
            var tela = new TelaBoasVindas("T", "D", "I", 1, true);
            tela.Id = 10;

            Assert.Equal(10, tela.Id);
        }
    }
}