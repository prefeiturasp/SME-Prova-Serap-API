using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class ModalidadeTest
    {
        [Fact]
        public void Deve_Conter_Membro_NaoCadastrado_Com_Valor_0()
        {
            Assert.Equal(0, (int)Modalidade.NaoCadastrado);
        }

        [Fact]
        public void Deve_Conter_Membro_EducacaoInfantil_Com_Valor_1()
        {
            Assert.Equal(1, (int)Modalidade.EducacaoInfantil);
        }

        [Fact]
        public void Deve_Conter_Membro_EJA_Com_Valor_3()
        {
            Assert.Equal(3, (int)Modalidade.EJA);
        }

        [Fact]
        public void Deve_Conter_Membro_CIEJA_Com_Valor_4()
        {
            Assert.Equal(4, (int)Modalidade.CIEJA);
        }

        [Fact]
        public void Deve_Conter_Membro_Fundamental_Com_Valor_5()
        {
            Assert.Equal(5, (int)Modalidade.Fundamental);
        }

        [Fact]
        public void Deve_Conter_Membro_Medio_Com_Valor_6()
        {
            Assert.Equal(6, (int)Modalidade.Medio);
        }

        [Fact]
        public void Deve_Conter_Membro_CMCT_Com_Valor_7()
        {
            Assert.Equal(7, (int)Modalidade.CMCT);
        }

        [Fact]
        public void Deve_Conter_Membro_MOVA_Com_Valor_8()
        {
            Assert.Equal(8, (int)Modalidade.MOVA);
        }

        [Fact]
        public void Deve_Conter_Membro_ETEC_Com_Valor_9()
        {
            Assert.Equal(9, (int)Modalidade.ETEC);
        }

        [Fact]
        public void Deve_Ter_NaoCadastrado_Como_Valor_Default()
        {
            var valor = default(Modalidade);
            Assert.Equal(Modalidade.NaoCadastrado, valor);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Nove_Membros()
        {
            var valores = Enum.GetValues(typeof(Modalidade));
            Assert.Equal(9, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (Modalidade[])Enum.GetValues(typeof(Modalidade));
            Assert.Contains(Modalidade.NaoCadastrado, valores);
            Assert.Contains(Modalidade.EducacaoInfantil, valores);
            Assert.Contains(Modalidade.EJA, valores);
            Assert.Contains(Modalidade.CIEJA, valores);
            Assert.Contains(Modalidade.Fundamental, valores);
            Assert.Contains(Modalidade.Medio, valores);
            Assert.Contains(Modalidade.CMCT, valores);
            Assert.Contains(Modalidade.MOVA, valores);
            Assert.Contains(Modalidade.ETEC, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(Modalidade.NaoCadastrado, (Modalidade)0);
            Assert.Equal(Modalidade.Fundamental, (Modalidade)5);
            Assert.Equal(Modalidade.ETEC, (Modalidade)9);
        }
    }
}