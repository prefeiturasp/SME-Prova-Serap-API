using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class AlternativaOrdemDtoTest
    {
        [Fact]
        public void Deve_Criar_AlternativaOrdemDto_Com_Construtor_Parametros()
        {
            var dto = new AlternativaOrdemDto(1, 2, 3);

            Assert.Equal(1, dto.AlternativaId);
            Assert.Equal(2, dto.AlternativaLegadoId);
            Assert.Equal(3, dto.Ordem);
        }

        [Fact]
        public void Deve_Atribuir_AlternativaId_Corretamente()
        {
            var dto = new AlternativaOrdemDto(99, 1, 1);
            Assert.Equal(99, dto.AlternativaId);
        }

        [Fact]
        public void Deve_Atribuir_AlternativaLegadoId_Corretamente()
        {
            var dto = new AlternativaOrdemDto(1, 77, 1);
            Assert.Equal(77, dto.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Atribuir_Ordem_Corretamente()
        {
            var dto = new AlternativaOrdemDto(1, 1, 5);
            Assert.Equal(5, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Ordem_Zero()
        {
            var dto = new AlternativaOrdemDto(1, 1, 0);
            Assert.Equal(0, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Ordem_Negativa()
        {
            var dto = new AlternativaOrdemDto(1, 1, -1);
            Assert.Equal(-1, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long()
        {
            var dto = new AlternativaOrdemDto(long.MaxValue, long.MaxValue, int.MaxValue);

            Assert.Equal(long.MaxValue, dto.AlternativaId);
            Assert.Equal(long.MaxValue, dto.AlternativaLegadoId);
            Assert.Equal(int.MaxValue, dto.Ordem);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new AlternativaOrdemDto(1, 2, 3);
            dto.AlternativaId = 10;
            dto.AlternativaLegadoId = 20;
            dto.Ordem = 30;

            Assert.Equal(10, dto.AlternativaId);
            Assert.Equal(20, dto.AlternativaLegadoId);
            Assert.Equal(30, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_AlternativaId_E_LegadoId_Iguais()
        {
            var dto = new AlternativaOrdemDto(5, 5, 1);
            Assert.Equal(dto.AlternativaId, dto.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Aceitar_AlternativaId_E_LegadoId_Diferentes()
        {
            var dto = new AlternativaOrdemDto(5, 10, 1);
            Assert.NotEqual(dto.AlternativaId, dto.AlternativaLegadoId);
        }
    }
}