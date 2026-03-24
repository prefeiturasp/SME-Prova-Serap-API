using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class ProvaFormatoTaiItemTest
    {
        [Fact]
        public void Deve_Conter_Membro_Todos_Com_Valor_0()
        {
            Assert.Equal(0, (int)ProvaFormatoTaiItem.Todos);
        }

        [Fact]
        public void Deve_Conter_Membro_Item20_Com_Valor_20()
        {
            Assert.Equal(20, (int)ProvaFormatoTaiItem.Item_20);
        }

        [Fact]
        public void Deve_Conter_Membro_Item30_Com_Valor_30()
        {
            Assert.Equal(30, (int)ProvaFormatoTaiItem.Item_30);
        }

        [Fact]
        public void Deve_Conter_Membro_Item40_Com_Valor_40()
        {
            Assert.Equal(40, (int)ProvaFormatoTaiItem.Item_40);
        }

        [Fact]
        public void Deve_Conter_Membro_Item50_Com_Valor_50()
        {
            Assert.Equal(50, (int)ProvaFormatoTaiItem.Item_50);
        }

        [Fact]
        public void Deve_Ter_Todos_Como_Valor_Default()
        {
            var valor = default(ProvaFormatoTaiItem);
            Assert.Equal(ProvaFormatoTaiItem.Todos, valor);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Cinco_Membros()
        {
            var valores = Enum.GetValues(typeof(ProvaFormatoTaiItem));
            Assert.Equal(5, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (ProvaFormatoTaiItem[])Enum.GetValues(typeof(ProvaFormatoTaiItem));
            Assert.Contains(ProvaFormatoTaiItem.Todos, valores);
            Assert.Contains(ProvaFormatoTaiItem.Item_20, valores);
            Assert.Contains(ProvaFormatoTaiItem.Item_30, valores);
            Assert.Contains(ProvaFormatoTaiItem.Item_40, valores);
            Assert.Contains(ProvaFormatoTaiItem.Item_50, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(ProvaFormatoTaiItem.Todos, (ProvaFormatoTaiItem)0);
            Assert.Equal(ProvaFormatoTaiItem.Item_20, (ProvaFormatoTaiItem)20);
            Assert.Equal(ProvaFormatoTaiItem.Item_30, (ProvaFormatoTaiItem)30);
            Assert.Equal(ProvaFormatoTaiItem.Item_40, (ProvaFormatoTaiItem)40);
            Assert.Equal(ProvaFormatoTaiItem.Item_50, (ProvaFormatoTaiItem)50);
        }

        [Fact]
        public void Deve_Comparar_Itens_Em_Ordem_Crescente()
        {
            Assert.True(ProvaFormatoTaiItem.Todos < ProvaFormatoTaiItem.Item_20);
            Assert.True(ProvaFormatoTaiItem.Item_20 < ProvaFormatoTaiItem.Item_30);
            Assert.True(ProvaFormatoTaiItem.Item_30 < ProvaFormatoTaiItem.Item_40);
            Assert.True(ProvaFormatoTaiItem.Item_40 < ProvaFormatoTaiItem.Item_50);
        }
    }
}