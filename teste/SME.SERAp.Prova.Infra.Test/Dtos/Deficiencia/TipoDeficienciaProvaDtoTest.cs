using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Deficiencia
{
    public class TipoDeficienciaProvaDtoTest
    {
        [Fact]
        public void Deve_Criar_TipoDeficienciaProvaDto_Com_Construtor_Padrao()
        {
            var dto = new TipoDeficienciaProvaDto();

            Assert.Equal(0, dto.DeficienciaId);
            Assert.Equal(0, dto.ProvaId);
            Assert.Equal(0, dto.DeficienciaCodigoEol);
        }

        [Fact]
        public void Deve_Atribuir_DeficienciaId_Corretamente()
        {
            var dto = new TipoDeficienciaProvaDto { DeficienciaId = 5 };
            Assert.Equal(5, dto.DeficienciaId);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new TipoDeficienciaProvaDto { ProvaId = 100 };
            Assert.Equal(100, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_DeficienciaCodigoEol_Corretamente()
        {
            var dto = new TipoDeficienciaProvaDto { DeficienciaCodigoEol = 7 };
            Assert.Equal(7, dto.DeficienciaCodigoEol);
        }

        [Fact]
        public void Deve_Criar_TipoDeficienciaProvaDto_Completo()
        {
            var dto = new TipoDeficienciaProvaDto
            {
                DeficienciaId = 3,
                ProvaId = 50,
                DeficienciaCodigoEol = 12
            };

            Assert.Equal(3, dto.DeficienciaId);
            Assert.Equal(50, dto.ProvaId);
            Assert.Equal(12, dto.DeficienciaCodigoEol);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long()
        {
            var dto = new TipoDeficienciaProvaDto
            {
                DeficienciaId = long.MaxValue,
                ProvaId = long.MaxValue
            };

            Assert.Equal(long.MaxValue, dto.DeficienciaId);
            Assert.Equal(long.MaxValue, dto.ProvaId);
        }

        [Fact]
        public void Deve_Aceitar_DeficienciaCodigoEol_Negativo()
        {
            var dto = new TipoDeficienciaProvaDto { DeficienciaCodigoEol = -1 };
            Assert.Equal(-1, dto.DeficienciaCodigoEol);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new TipoDeficienciaProvaDto { DeficienciaId = 1, ProvaId = 2, DeficienciaCodigoEol = 3 };
            dto.DeficienciaId = 10;
            dto.ProvaId = 20;
            dto.DeficienciaCodigoEol = 30;

            Assert.Equal(10, dto.DeficienciaId);
            Assert.Equal(20, dto.ProvaId);
            Assert.Equal(30, dto.DeficienciaCodigoEol);
        }
    }
}