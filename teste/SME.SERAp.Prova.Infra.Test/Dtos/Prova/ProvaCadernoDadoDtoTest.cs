using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaCadernoDadoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaCadernoDadoDto_Com_Propriedade_Padrao()
        {
            var dto = new ProvaCadernoDadoDto();
            Assert.Null(dto.Caderno);
        }

        [Fact]
        public void Deve_Atribuir_Caderno_Corretamente()
        {
            var dto = new ProvaCadernoDadoDto { Caderno = "A" };
            Assert.Equal("A", dto.Caderno);
        }

        [Fact]
        public void Deve_Aceitar_Caderno_Nulo()
        {
            var dto = new ProvaCadernoDadoDto { Caderno = null };
            Assert.Null(dto.Caderno);
        }

        [Fact]
        public void Deve_Aceitar_Caderno_Vazio()
        {
            var dto = new ProvaCadernoDadoDto { Caderno = string.Empty };
            Assert.Equal(string.Empty, dto.Caderno);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Caderno_Apos_Atribuicao()
        {
            var dto = new ProvaCadernoDadoDto { Caderno = "A" };
            dto.Caderno = "B";
            Assert.Equal("B", dto.Caderno);
        }
    }
}