namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaCadernoRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaCadernoRetornoDto_Com_Propriedade_Padrao()
        {
            var dto = new ProvaCadernoRetornoDto();
            Assert.Null(dto.Cadernos);
        }

        [Fact]
        public void Deve_Atribuir_Array_Cadernos_Corretamente()
        {
            var dto = new ProvaCadernoRetornoDto { Cadernos = new[] { "A", "B", "C" } };

            Assert.Equal(3, dto.Cadernos.Length);
            Assert.Equal("A", dto.Cadernos[0]);
            Assert.Equal("B", dto.Cadernos[1]);
            Assert.Equal("C", dto.Cadernos[2]);
        }

        [Fact]
        public void Deve_Aceitar_Array_Cadernos_Vazio()
        {
            var dto = new ProvaCadernoRetornoDto { Cadernos = System.Array.Empty<string>() };
            Assert.Empty(dto.Cadernos);
        }

        [Fact]
        public void Deve_Aceitar_Cadernos_Nulo()
        {
            var dto = new ProvaCadernoRetornoDto { Cadernos = null };
            Assert.Null(dto.Cadernos);
        }

        [Fact]
        public void Deve_Aceitar_Array_Com_Um_Caderno()
        {
            var dto = new ProvaCadernoRetornoDto { Cadernos = new[] { "Único" } };
            Assert.Single(dto.Cadernos);
            Assert.Equal("Único", dto.Cadernos[0]);
        }
    }
}