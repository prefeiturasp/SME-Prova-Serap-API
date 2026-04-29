using System.Collections.Generic;
using System.Linq;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaExtracaoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaExtracaoDto_Com_Construtor_Padrao()
        {
            var dto = new ProvaExtracaoDto();

            Assert.Equal(0, dto.ProvaSerapId);
            Assert.Equal(0, dto.ExtracaoResultadoId);
        }

        [Fact]
        public void Deve_Atribuir_ProvaSerapId_Corretamente()
        {
            var dto = new ProvaExtracaoDto { ProvaSerapId = 42 };
            Assert.Equal(42, dto.ProvaSerapId);
        }

        [Fact]
        public void Deve_Atribuir_ExtracaoResultadoId_Corretamente()
        {
            var dto = new ProvaExtracaoDto { ExtracaoResultadoId = 77 };
            Assert.Equal(77, dto.ExtracaoResultadoId);
        }

        [Fact]
        public void Deve_Criar_ProvaExtracaoDto_Completo()
        {
            var dto = new ProvaExtracaoDto { ProvaSerapId = 10, ExtracaoResultadoId = 20 };

            Assert.Equal(10, dto.ProvaSerapId);
            Assert.Equal(20, dto.ExtracaoResultadoId);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long()
        {
            var dto = new ProvaExtracaoDto { ProvaSerapId = long.MaxValue, ExtracaoResultadoId = long.MaxValue };

            Assert.Equal(long.MaxValue, dto.ProvaSerapId);
            Assert.Equal(long.MaxValue, dto.ExtracaoResultadoId);
        }
    }
}