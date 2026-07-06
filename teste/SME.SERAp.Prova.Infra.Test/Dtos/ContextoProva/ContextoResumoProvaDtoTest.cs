using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ContextoProva
{
    public class ContextoResumoProvaDtoTest
    {
        [Fact]
        public void Deve_Criar_ContextoResumoProvaDto_Com_Propriedade_Padrao()
        {
            var dto = new ContextoResumoProvaDto();
            Assert.Equal(0, dto.ContextoProvaId);
        }

        [Fact]
        public void Deve_Atribuir_ContextoProvaId_Corretamente()
        {
            var dto = new ContextoResumoProvaDto { ContextoProvaId = 42 };
            Assert.Equal(42, dto.ContextoProvaId);
        }

        [Fact]
        public void Deve_Aceitar_ContextoProvaId_Zero()
        {
            var dto = new ContextoResumoProvaDto { ContextoProvaId = 0 };
            Assert.Equal(0, dto.ContextoProvaId);
        }

        [Fact]
        public void Deve_Aceitar_ContextoProvaId_Valor_Maximo_Long()
        {
            var dto = new ContextoResumoProvaDto { ContextoProvaId = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.ContextoProvaId);
        }

        [Fact]
        public void Deve_Permitir_Alterar_ContextoProvaId()
        {
            var dto = new ContextoResumoProvaDto { ContextoProvaId = 10 };
            dto.ContextoProvaId = 20;
            Assert.Equal(20, dto.ContextoProvaId);
        }
    }
}