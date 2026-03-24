using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class QuestaoTipoTest
    {
        [Fact]
        public void Deve_Conter_Membro_NaoCadastrado_Com_Valor_0()
        {
            Assert.Equal(0, (int)QuestaoTipo.NaoCadastrado);
        }

        [Fact]
        public void Deve_Conter_Membro_MultiplaEscolha_Com_Valor_1()
        {
            Assert.Equal(1, (int)QuestaoTipo.MultiplaEscolha);
        }

        [Fact]
        public void Deve_Conter_Membro_RespostaConstruida_Com_Valor_2()
        {
            Assert.Equal(2, (int)QuestaoTipo.RespostaConstruida);
        }

        [Fact]
        public void Deve_Ter_NaoCadastrado_Como_Valor_Default()
        {
            var valor = default(QuestaoTipo);
            Assert.Equal(QuestaoTipo.NaoCadastrado, valor);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Tres_Membros()
        {
            var valores = Enum.GetValues(typeof(QuestaoTipo));
            Assert.Equal(3, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (QuestaoTipo[])Enum.GetValues(typeof(QuestaoTipo));
            Assert.Contains(QuestaoTipo.NaoCadastrado, valores);
            Assert.Contains(QuestaoTipo.MultiplaEscolha, valores);
            Assert.Contains(QuestaoTipo.RespostaConstruida, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(QuestaoTipo.NaoCadastrado, (QuestaoTipo)0);
            Assert.Equal(QuestaoTipo.MultiplaEscolha, (QuestaoTipo)1);
            Assert.Equal(QuestaoTipo.RespostaConstruida, (QuestaoTipo)2);
        }
    }
}