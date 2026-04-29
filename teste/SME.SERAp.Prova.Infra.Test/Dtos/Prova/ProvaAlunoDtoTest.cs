using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaAlunoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaAlunoDto_Com_Construtor_Parametros()
        {
            var dto = new ProvaAlunoDto(10, 2);

            Assert.Equal(10, dto.ProvaId);
            Assert.Equal(2, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new ProvaAlunoDto(99, 1);
            Assert.Equal(99, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_Status_Corretamente()
        {
            var dto = new ProvaAlunoDto(1, 3);
            Assert.Equal(3, dto.Status);
        }

        [Fact]
        public void Deve_Aceitar_Status_Zero()
        {
            var dto = new ProvaAlunoDto(1, 0);
            Assert.Equal(0, dto.Status);
        }

        [Fact]
        public void Deve_Aceitar_Status_Negativo()
        {
            var dto = new ProvaAlunoDto(1, -1);
            Assert.Equal(-1, dto.Status);
        }

        [Fact]
        public void Deve_Aceitar_ProvaId_Valor_Maximo_Long()
        {
            var dto = new ProvaAlunoDto(long.MaxValue, 1);
            Assert.Equal(long.MaxValue, dto.ProvaId);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new ProvaAlunoDto(1, 1);
            dto.ProvaId = 50;
            dto.Status = 5;

            Assert.Equal(50, dto.ProvaId);
            Assert.Equal(5, dto.Status);
        }
    }
}