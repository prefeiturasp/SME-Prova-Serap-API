using SME.SERAp.Prova.Infra.ImagemLog;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ImagemLog
{
    public class ImagemLogDtoTest
    {
        [Fact]
        public void Deve_Criar_ImagemLogDto_Com_Propriedades_Padrao()
        {
            var dto = new ImagemLogDto();

            Assert.Null(dto.Prova);
            Assert.Null(dto.Aluno);
            Assert.Null(dto.Escola);
            Assert.Null(dto.Html);
        }

        [Fact]
        public void Deve_Atribuir_Prova_Corretamente()
        {
            var dto = new ImagemLogDto { Prova = "Prova de Matemática" };

            Assert.Equal("Prova de Matemática", dto.Prova);
        }

        [Fact]
        public void Deve_Atribuir_Aluno_Corretamente()
        {
            var dto = new ImagemLogDto { Aluno = "João da Silva" };

            Assert.Equal("João da Silva", dto.Aluno);
        }

        [Fact]
        public void Deve_Atribuir_Escola_Corretamente()
        {
            var dto = new ImagemLogDto { Escola = "EMEF Teste" };

            Assert.Equal("EMEF Teste", dto.Escola);
        }

        [Fact]
        public void Deve_Atribuir_Html_Corretamente()
        {
            var html = "<html><body><p>Conteúdo</p></body></html>";
            var dto = new ImagemLogDto { Html = html };

            Assert.Equal(html, dto.Html);
        }

        [Fact]
        public void Deve_Criar_ImagemLogDto_Completo()
        {
            var dto = new ImagemLogDto
            {
                Prova = "Prova de Português",
                Aluno = "Maria Oliveira",
                Escola = "EMEI Central",
                Html = "<html><body>Resultado</body></html>"
            };

            Assert.Equal("Prova de Português", dto.Prova);
            Assert.Equal("Maria Oliveira", dto.Aluno);
            Assert.Equal("EMEI Central", dto.Escola);
            Assert.Equal("<html><body>Resultado</body></html>", dto.Html);
        }

        [Fact]
        public void Deve_Aceitar_Prova_Nula()
        {
            var dto = new ImagemLogDto { Prova = null };

            Assert.Null(dto.Prova);
        }

        [Fact]
        public void Deve_Aceitar_Aluno_Nulo()
        {
            var dto = new ImagemLogDto { Aluno = null };

            Assert.Null(dto.Aluno);
        }

        [Fact]
        public void Deve_Aceitar_Escola_Nula()
        {
            var dto = new ImagemLogDto { Escola = null };

            Assert.Null(dto.Escola);
        }

        [Fact]
        public void Deve_Aceitar_Html_Nulo()
        {
            var dto = new ImagemLogDto { Html = null };

            Assert.Null(dto.Html);
        }

        [Fact]
        public void Deve_Aceitar_Prova_Vazia()
        {
            var dto = new ImagemLogDto { Prova = string.Empty };

            Assert.Equal(string.Empty, dto.Prova);
        }

        [Fact]
        public void Deve_Aceitar_Aluno_Vazio()
        {
            var dto = new ImagemLogDto { Aluno = string.Empty };

            Assert.Equal(string.Empty, dto.Aluno);
        }

        [Fact]
        public void Deve_Aceitar_Escola_Vazia()
        {
            var dto = new ImagemLogDto { Escola = string.Empty };

            Assert.Equal(string.Empty, dto.Escola);
        }

        [Fact]
        public void Deve_Aceitar_Html_Vazio()
        {
            var dto = new ImagemLogDto { Html = string.Empty };

            Assert.Equal(string.Empty, dto.Html);
        }

        [Fact]
        public void Deve_Aceitar_Html_Com_Tags_Complexas()
        {
            var html = "<html><head><title>Prova</title></head><body><table><tr><td>Item 1</td></tr></table></body></html>";
            var dto = new ImagemLogDto { Html = html };

            Assert.Equal(html, dto.Html);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Atribuicao()
        {
            var dto = new ImagemLogDto
            {
                Prova = "Original",
                Aluno = "Aluno A",
                Escola = "Escola A",
                Html = "<p>old</p>"
            };

            dto.Prova = "Alterada";
            dto.Aluno = "Aluno B";
            dto.Escola = "Escola B";
            dto.Html = "<p>new</p>";

            Assert.Equal("Alterada", dto.Prova);
            Assert.Equal("Aluno B", dto.Aluno);
            Assert.Equal("Escola B", dto.Escola);
            Assert.Equal("<p>new</p>", dto.Html);
        }

        [Fact]
        public void Deve_Aceitar_Html_Longo()
        {
            var html = new string('x', 10000);
            var dto = new ImagemLogDto { Html = html };

            Assert.Equal(html, dto.Html);
            Assert.Equal(10000, dto.Html.Length);
        }
    }
}