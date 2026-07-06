using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class PosicionamentoTest
    {
        [Fact]
        public void Deve_Conter_Membro_NaoCadastrado_Com_Valor_0()
        {
            Assert.Equal(0, (int)Posicionamento.NaoCadastrado);
        }

        [Fact]
        public void Deve_Conter_Membro_Direita_Com_Valor_1()
        {
            Assert.Equal(1, (int)Posicionamento.Direita);
        }

        [Fact]
        public void Deve_Conter_Membro_Centro_Com_Valor_2()
        {
            Assert.Equal(2, (int)Posicionamento.Centro);
        }

        [Fact]
        public void Deve_Conter_Membro_Esquerda_Com_Valor_3()
        {
            Assert.Equal(3, (int)Posicionamento.Esquerda);
        }

        [Fact]
        public void Deve_Ter_NaoCadastrado_Como_Valor_Default()
        {
            var valor = default(Posicionamento);
            Assert.Equal(Posicionamento.NaoCadastrado, valor);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Quatro_Membros()
        {
            var valores = Enum.GetValues(typeof(Posicionamento));
            Assert.Equal(4, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (Posicionamento[])Enum.GetValues(typeof(Posicionamento));
            Assert.Contains(Posicionamento.NaoCadastrado, valores);
            Assert.Contains(Posicionamento.Direita, valores);
            Assert.Contains(Posicionamento.Centro, valores);
            Assert.Contains(Posicionamento.Esquerda, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(Posicionamento.NaoCadastrado, (Posicionamento)0);
            Assert.Equal(Posicionamento.Direita, (Posicionamento)1);
            Assert.Equal(Posicionamento.Centro, (Posicionamento)2);
            Assert.Equal(Posicionamento.Esquerda, (Posicionamento)3);
        }
    }
}