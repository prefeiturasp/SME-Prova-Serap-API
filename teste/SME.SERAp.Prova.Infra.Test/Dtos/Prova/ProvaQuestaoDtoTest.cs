namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaQuestaoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaQuestaoDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaQuestaoDto();

            Assert.Equal(0, dto.ProvaId);
            Assert.Equal(0, dto.ProvaLegadoId);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new ProvaQuestaoDto { ProvaId = 15 };
            Assert.Equal(15, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_ProvaLegadoId_Corretamente()
        {
            var dto = new ProvaQuestaoDto { ProvaLegadoId = 30 };
            Assert.Equal(30, dto.ProvaLegadoId);
        }

        [Fact]
        public void Deve_Aceitar_ProvaId_E_ProvaLegadoId_Iguais()
        {
            var dto = new ProvaQuestaoDto { ProvaId = 7, ProvaLegadoId = 7 };
            Assert.Equal(dto.ProvaId, dto.ProvaLegadoId);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long()
        {
            var dto = new ProvaQuestaoDto { ProvaId = long.MaxValue, ProvaLegadoId = long.MaxValue };

            Assert.Equal(long.MaxValue, dto.ProvaId);
            Assert.Equal(long.MaxValue, dto.ProvaLegadoId);
        }
    }
}