using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ExportacaoResultado
{
    public class ExportacaoRetornoSerapDtoTest
    {
        [Fact]
        public void Deve_Criar_ExportacaoRetornoSerapDto_Com_Propriedades_Padrao()
        {
            var dto = new ExportacaoRetornoSerapDto();

            Assert.Equal(0, dto.Test_Id);
            Assert.Null(dto.TestDescription);
            Assert.Null(dto.ApplicationStartDate);
            Assert.Null(dto.ApplicationEndDate);
            Assert.Null(dto.TestTypeDescription);
            Assert.Equal(0, dto.StateExecution);
            Assert.Null(dto.CreateDate);
            Assert.Null(dto.UpdateDate);
            Assert.Equal(0, dto.FileId);
        }

        [Fact]
        public void Deve_Atribuir_Test_Id_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { Test_Id = 500 };
            Assert.Equal(500, dto.Test_Id);
        }

        [Fact]
        public void Deve_Atribuir_TestDescription_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { TestDescription = "Prova Serap 2024" };
            Assert.Equal("Prova Serap 2024", dto.TestDescription);
        }

        [Fact]
        public void Deve_Atribuir_ApplicationStartDate_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { ApplicationStartDate = "2024-01-15" };
            Assert.Equal("2024-01-15", dto.ApplicationStartDate);
        }

        [Fact]
        public void Deve_Atribuir_ApplicationEndDate_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { ApplicationEndDate = "2024-01-30" };
            Assert.Equal("2024-01-30", dto.ApplicationEndDate);
        }

        [Fact]
        public void Deve_Atribuir_TestTypeDescription_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { TestTypeDescription = "Diagnóstica" };
            Assert.Equal("Diagnóstica", dto.TestTypeDescription);
        }

        [Fact]
        public void Deve_Atribuir_StateExecution_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { StateExecution = 2 };
            Assert.Equal(2, dto.StateExecution);
        }

        [Fact]
        public void Deve_Atribuir_CreateDate_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { CreateDate = "2024-01-01T00:00:00" };
            Assert.Equal("2024-01-01T00:00:00", dto.CreateDate);
        }

        [Fact]
        public void Deve_Atribuir_UpdateDate_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { UpdateDate = "2024-06-01T12:00:00" };
            Assert.Equal("2024-06-01T12:00:00", dto.UpdateDate);
        }

        [Fact]
        public void Deve_Atribuir_FileId_Corretamente()
        {
            var dto = new ExportacaoRetornoSerapDto { FileId = 77 };
            Assert.Equal(77, dto.FileId);
        }

        [Fact]
        public void Deve_Criar_ExportacaoRetornoSerapDto_Completo()
        {
            var dto = new ExportacaoRetornoSerapDto
            {
                Test_Id = 101,
                TestDescription = "Avaliação SERAP",
                ApplicationStartDate = "2024-02-01",
                ApplicationEndDate = "2024-02-28",
                TestTypeDescription = "Somativa",
                StateExecution = 1,
                CreateDate = "2024-01-10",
                UpdateDate = "2024-02-05",
                FileId = 88
            };

            Assert.Equal(101, dto.Test_Id);
            Assert.Equal("Avaliação SERAP", dto.TestDescription);
            Assert.Equal("2024-02-01", dto.ApplicationStartDate);
            Assert.Equal("2024-02-28", dto.ApplicationEndDate);
            Assert.Equal("Somativa", dto.TestTypeDescription);
            Assert.Equal(1, dto.StateExecution);
            Assert.Equal("2024-01-10", dto.CreateDate);
            Assert.Equal("2024-02-05", dto.UpdateDate);
            Assert.Equal(88, dto.FileId);
        }

        [Fact]
        public void Deve_Aceitar_Strings_Nulas()
        {
            var dto = new ExportacaoRetornoSerapDto
            {
                TestDescription = null,
                ApplicationStartDate = null,
                ApplicationEndDate = null,
                TestTypeDescription = null,
                CreateDate = null,
                UpdateDate = null
            };

            Assert.Null(dto.TestDescription);
            Assert.Null(dto.ApplicationStartDate);
            Assert.Null(dto.ApplicationEndDate);
            Assert.Null(dto.TestTypeDescription);
            Assert.Null(dto.CreateDate);
            Assert.Null(dto.UpdateDate);
        }

        [Fact]
        public void Deve_Aceitar_FileId_Valor_Maximo_Long()
        {
            var dto = new ExportacaoRetornoSerapDto { FileId = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.FileId);
        }

        [Fact]
        public void Deve_Aceitar_StateExecution_Negativo()
        {
            var dto = new ExportacaoRetornoSerapDto { StateExecution = -1 };
            Assert.Equal(-1, dto.StateExecution);
        }
    }
}