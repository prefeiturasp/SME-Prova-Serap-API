using SME.SERAp.Prova.Infra.Dtos.Prova;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaAlunoReabrirDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaAlunoReabrirDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaAlunoReabrirDto();

            Assert.Equal(0, dto.ProvaId);
            Assert.Equal(0, dto.AlunoRA);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new ProvaAlunoReabrirDto { ProvaId = 42 };
            Assert.Equal(42, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_AlunoRA_Corretamente()
        {
            var dto = new ProvaAlunoReabrirDto { AlunoRA = 123456 };
            Assert.Equal(123456, dto.AlunoRA);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoReabrirDto_Completo()
        {
            var dto = new ProvaAlunoReabrirDto { ProvaId = 10, AlunoRA = 987654 };

            Assert.Equal(10, dto.ProvaId);
            Assert.Equal(987654, dto.AlunoRA);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long()
        {
            var dto = new ProvaAlunoReabrirDto { ProvaId = long.MaxValue, AlunoRA = long.MaxValue };

            Assert.Equal(long.MaxValue, dto.ProvaId);
            Assert.Equal(long.MaxValue, dto.AlunoRA);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Atribuicao()
        {
            var dto = new ProvaAlunoReabrirDto { ProvaId = 1, AlunoRA = 1 };
            dto.ProvaId = 99;
            dto.AlunoRA = 99999;

            Assert.Equal(99, dto.ProvaId);
            Assert.Equal(99999, dto.AlunoRA);
        }
    }
}