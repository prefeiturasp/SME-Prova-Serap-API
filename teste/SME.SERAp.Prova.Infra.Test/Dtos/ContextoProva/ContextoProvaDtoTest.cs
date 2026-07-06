using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ContextoProva
{
    public class ContextoProvaDtoTest
    {
        [Fact]
        public void Deve_Criar_ContextoProvaDto_Com_Construtor_Parametros()
        {
            var dto = new ContextoProvaDto(1, 10, "Título", "Texto do contexto", "/img/ctx.png", Posicionamento.Direita, 2);

            Assert.Equal(1, dto.Id);
            Assert.Equal(10, dto.ProvaId);
            Assert.Equal("Título", dto.Titulo);
            Assert.Equal("Texto do contexto", dto.Texto);
            Assert.Equal("/img/ctx.png", dto.Imagem);
            Assert.Equal(Posicionamento.Direita, dto.Posicionamento);
            Assert.Equal(2, dto.Ordem);
        }

        [Fact]
        public void Deve_Atribuir_Id_Corretamente()
        {
            var dto = new ContextoProvaDto(55, 1, "T", "X", "I", Posicionamento.Direita, 1);
            Assert.Equal(55, dto.Id);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new ContextoProvaDto(1, 77, "T", "X", "I", Posicionamento.Direita, 1);
            Assert.Equal(77, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_Titulo_Corretamente()
        {
            var dto = new ContextoProvaDto(1, 1, "Meu Título", "X", "I", Posicionamento.Direita, 1);
            Assert.Equal("Meu Título", dto.Titulo);
        }

        [Fact]
        public void Deve_Atribuir_Texto_Corretamente()
        {
            var dto = new ContextoProvaDto(1, 1, "T", "Texto longo aqui", "I", Posicionamento.Direita, 1);
            Assert.Equal("Texto longo aqui", dto.Texto);
        }

        [Fact]
        public void Deve_Atribuir_Imagem_Corretamente()
        {
            var dto = new ContextoProvaDto(1, 1, "T", "X", "/contexto/img.png", Posicionamento.Direita, 1);
            Assert.Equal("/contexto/img.png", dto.Imagem);
        }

        [Fact]
        public void Deve_Atribuir_Posicionamento_Esquerda()
        {
            var dto = new ContextoProvaDto(1, 1, "T", "X", "I", Posicionamento.Direita, 1);
            Assert.Equal(Posicionamento.Direita, dto.Posicionamento);
        }

        [Fact]
        public void Deve_Atribuir_Posicionamento_Direita()
        {
            var dto = new ContextoProvaDto(1, 1, "T", "X", "I", Posicionamento.Esquerda, 1);
            Assert.Equal(Posicionamento.Esquerda, dto.Posicionamento);
        }

        [Fact]
        public void Deve_Atribuir_Ordem_Corretamente()
        {
            var dto = new ContextoProvaDto(1, 1, "T", "X", "I", Posicionamento.Direita, 7);
            Assert.Equal(7, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Titulo_Nulo()
        {
            var dto = new ContextoProvaDto(1, 1, null, "X", "I", Posicionamento.Direita, 1);
            Assert.Null(dto.Titulo);
        }

        [Fact]
        public void Deve_Aceitar_Texto_Nulo()
        {
            var dto = new ContextoProvaDto(1, 1, "T", null, "I", Posicionamento.Direita, 1);
            Assert.Null(dto.Texto);
        }

        [Fact]
        public void Deve_Aceitar_Imagem_Nula()
        {
            var dto = new ContextoProvaDto(1, 1, "T", "X", null, Posicionamento.Direita, 1);
            Assert.Null(dto.Imagem);
        }

        [Fact]
        public void Deve_Aceitar_Ordem_Zero()
        {
            var dto = new ContextoProvaDto(1, 1, "T", "X", "I", Posicionamento.Direita, 0);
            Assert.Equal(0, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Id_Valor_Maximo_Long()
        {
            var dto = new ContextoProvaDto(long.MaxValue, long.MaxValue, "T", "X", "I", Posicionamento.Direita, 1);
            Assert.Equal(long.MaxValue, dto.Id);
            Assert.Equal(long.MaxValue, dto.ProvaId);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new ContextoProvaDto(1, 1, "Original", "X", "I", Posicionamento.Direita, 1);
            dto.Titulo = "Novo Título";
            dto.Ordem = 99;

            Assert.Equal("Novo Título", dto.Titulo);
            Assert.Equal(99, dto.Ordem);
        }
    }
}