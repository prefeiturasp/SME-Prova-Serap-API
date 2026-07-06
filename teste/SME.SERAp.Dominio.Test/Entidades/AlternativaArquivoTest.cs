using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class AlternativaArquivoTest
    {
        [Fact]
        public void Deve_Criar_AlternativaArquivo_Com_Construtor_Padrao()
        {
            var alternativaArquivo = new AlternativaArquivo
            {
                ArquivoId = 1,
                AlternativaId = 2
            };

            Assert.Equal(1, alternativaArquivo.ArquivoId);
            Assert.Equal(2, alternativaArquivo.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_AlternativaArquivo_Com_Construtor_Parametros()
        {
            var alternativaArquivo = new AlternativaArquivo(10, 20);

            Assert.Equal(10, alternativaArquivo.ArquivoId);
            Assert.Equal(20, alternativaArquivo.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_AlternativaArquivo_Com_Ids_Iguais()
        {
            var alternativaArquivo = new AlternativaArquivo(5, 5);

            Assert.Equal(alternativaArquivo.ArquivoId, alternativaArquivo.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_AlternativaArquivo_Com_Ids_Maximos()
        {
            var alternativaArquivo = new AlternativaArquivo(long.MaxValue, long.MaxValue);

            Assert.Equal(long.MaxValue, alternativaArquivo.ArquivoId);
            Assert.Equal(long.MaxValue, alternativaArquivo.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_AlternativaArquivo_Com_Ids_Minimos()
        {
            var alternativaArquivo = new AlternativaArquivo(1, 1);

            Assert.Equal(1, alternativaArquivo.ArquivoId);
            Assert.Equal(1, alternativaArquivo.AlternativaId);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var alternativaArquivo = new AlternativaArquivo();
            alternativaArquivo.ArquivoId = 100;
            alternativaArquivo.AlternativaId = 200;

            Assert.Equal(100, alternativaArquivo.ArquivoId);
            Assert.Equal(200, alternativaArquivo.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_AlternativaArquivo_Com_Construtor_Padrao_E_Valores_Default()
        {
            var alternativaArquivo = new AlternativaArquivo();

            Assert.Equal(0, alternativaArquivo.ArquivoId);
            Assert.Equal(0, alternativaArquivo.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_AlternativaArquivo_Verificar_ArquivoId_Diferente_De_AlternativaId()
        {
            var alternativaArquivo = new AlternativaArquivo(1, 2);

            Assert.NotEqual(alternativaArquivo.ArquivoId, alternativaArquivo.AlternativaId);
        }
    }
}