using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Configuracao
{
    public class TelaBoasVindasDtoTest
    {
        [Fact]
        public void Deve_Criar_TelaBoasVindasDto_Com_Construtor_Parametros()
        {
            var dto = new TelaBoasVindasDto(1, "Bem-vindo", "Descrição da tela", "/imagens/boas_vindas.png", 1);

            Assert.Equal(1, dto.Id);
            Assert.Equal("Bem-vindo", dto.Titulo);
            Assert.Equal("Descrição da tela", dto.Descricao);
            Assert.Equal("/imagens/boas_vindas.png", dto.Imagem);
            Assert.Equal(1, dto.Ordem);
        }

        [Fact]
        public void Deve_Atribuir_Id_Corretamente()
        {
            var dto = new TelaBoasVindasDto(99, "T", "D", "I", 1);
            Assert.Equal(99, dto.Id);
        }

        [Fact]
        public void Deve_Atribuir_Titulo_Corretamente()
        {
            var dto = new TelaBoasVindasDto(1, "Meu Título", "D", "I", 1);
            Assert.Equal("Meu Título", dto.Titulo);
        }

        [Fact]
        public void Deve_Atribuir_Descricao_Corretamente()
        {
            var dto = new TelaBoasVindasDto(1, "T", "Minha Descrição", "I", 1);
            Assert.Equal("Minha Descrição", dto.Descricao);
        }

        [Fact]
        public void Deve_Atribuir_Imagem_Corretamente()
        {
            var dto = new TelaBoasVindasDto(1, "T", "D", "/img/foto.jpg", 1);
            Assert.Equal("/img/foto.jpg", dto.Imagem);
        }

        [Fact]
        public void Deve_Atribuir_Ordem_Corretamente()
        {
            var dto = new TelaBoasVindasDto(1, "T", "D", "I", 5);
            Assert.Equal(5, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Titulo_Nulo()
        {
            var dto = new TelaBoasVindasDto(1, null, "D", "I", 1);
            Assert.Null(dto.Titulo);
        }

        [Fact]
        public void Deve_Aceitar_Descricao_Nula()
        {
            var dto = new TelaBoasVindasDto(1, "T", null, "I", 1);
            Assert.Null(dto.Descricao);
        }

        [Fact]
        public void Deve_Aceitar_Imagem_Nula()
        {
            var dto = new TelaBoasVindasDto(1, "T", "D", null, 1);
            Assert.Null(dto.Imagem);
        }

        [Fact]
        public void Deve_Aceitar_Ordem_Zero()
        {
            var dto = new TelaBoasVindasDto(1, "T", "D", "I", 0);
            Assert.Equal(0, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Id_Valor_Maximo_Long()
        {
            var dto = new TelaBoasVindasDto(long.MaxValue, "T", "D", "I", 1);
            Assert.Equal(long.MaxValue, dto.Id);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new TelaBoasVindasDto(1, "Original", "Desc", "Img", 1);
            dto.Titulo = "Alterado";
            dto.Ordem = 10;

            Assert.Equal("Alterado", dto.Titulo);
            Assert.Equal(10, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Strings_Vazias()
        {
            var dto = new TelaBoasVindasDto(1, string.Empty, string.Empty, string.Empty, 1);

            Assert.Equal(string.Empty, dto.Titulo);
            Assert.Equal(string.Empty, dto.Descricao);
            Assert.Equal(string.Empty, dto.Imagem);
        }

        [Fact]
        public void Deve_Aceitar_Ordem_Negativa()
        {
            var dto = new TelaBoasVindasDto(1, "T", "D", "I", -1);
            Assert.Equal(-1, dto.Ordem);
        }
    }
}