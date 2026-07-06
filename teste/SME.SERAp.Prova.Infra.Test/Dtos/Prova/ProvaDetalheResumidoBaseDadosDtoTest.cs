using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaDetalheResumidoBaseDadosDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaDetalheResumidoBaseDadosDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaDetalheResumidoBaseDadosDto();

            Assert.Equal(0, dto.QuestaoId);
            Assert.Equal(0, dto.AlternativaId);
            Assert.Equal(0, dto.QuestaoArquivoId);
            Assert.Equal(0, dto.QuestaoArquivoTamanho);
            Assert.Equal(0, dto.AlternativaArquivoId);
            Assert.Equal(0, dto.AlternativaArquivoTamanho);
        }

        [Fact]
        public void Deve_Criar_ProvaDetalheResumidoBaseDadosDto_Completo()
        {
            var dto = new ProvaDetalheResumidoBaseDadosDto
            {
                QuestaoId = 1,
                AlternativaId = 2,
                QuestaoArquivoId = 3,
                QuestaoArquivoTamanho = 1024,
                AlternativaArquivoId = 4,
                AlternativaArquivoTamanho = 512
            };

            Assert.Equal(1, dto.QuestaoId);
            Assert.Equal(2, dto.AlternativaId);
            Assert.Equal(3, dto.QuestaoArquivoId);
            Assert.Equal(1024, dto.QuestaoArquivoTamanho);
            Assert.Equal(4, dto.AlternativaArquivoId);
            Assert.Equal(512, dto.AlternativaArquivoTamanho);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long()
        {
            var dto = new ProvaDetalheResumidoBaseDadosDto
            {
                QuestaoId = long.MaxValue,
                AlternativaId = long.MaxValue,
                QuestaoArquivoId = long.MaxValue,
                QuestaoArquivoTamanho = long.MaxValue,
                AlternativaArquivoId = long.MaxValue,
                AlternativaArquivoTamanho = long.MaxValue
            };

            Assert.Equal(long.MaxValue, dto.QuestaoId);
            Assert.Equal(long.MaxValue, dto.AlternativaArquivoTamanho);
        }
    }
}