using Xunit;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class QuestaoArquivoTest
    {
        [Fact]
        public void Deve_Criar_QuestaoArquivo_Com_Construtor_Padrao()
        {
            var qa = new QuestaoArquivo
            {
                QuestaoId = 1,
                ArquivoId = 2
            };

            Assert.Equal(1, qa.QuestaoId);
            Assert.Equal(2, qa.ArquivoId);
        }

        [Fact]
        public void Deve_Criar_QuestaoArquivo_Com_Construtor_Parametros()
        {
            var qa = new QuestaoArquivo(5, 6);

            Assert.Equal(5, qa.QuestaoId);
            Assert.Equal(6, qa.ArquivoId);
        }
    }
}