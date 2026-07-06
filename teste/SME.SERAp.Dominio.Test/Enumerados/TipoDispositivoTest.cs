using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class TipoDispositivoTest
    {
        [Fact]
        public void Deve_Conter_Membro_NaoCadastrado_Com_Valor_0()
        {
            Assert.Equal(0, (int)TipoDispositivo.NaoCadastrado);
        }

        [Fact]
        public void Deve_Conter_Membro_Mobile_Com_Valor_1()
        {
            Assert.Equal(1, (int)TipoDispositivo.Mobile);
        }

        [Fact]
        public void Deve_Conter_Membro_Tablet_Com_Valor_2()
        {
            Assert.Equal(2, (int)TipoDispositivo.Tablet);
        }

        [Fact]
        public void Deve_Conter_Membro_Web_Com_Valor_3()
        {
            Assert.Equal(3, (int)TipoDispositivo.Web);
        }

        [Fact]
        public void Deve_Ter_NaoCadastrado_Como_Valor_Default()
        {
            var valor = default(TipoDispositivo);
            Assert.Equal(TipoDispositivo.NaoCadastrado, valor);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Quatro_Membros()
        {
            var valores = Enum.GetValues(typeof(TipoDispositivo));
            Assert.Equal(4, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (TipoDispositivo[])Enum.GetValues(typeof(TipoDispositivo));
            Assert.Contains(TipoDispositivo.NaoCadastrado, valores);
            Assert.Contains(TipoDispositivo.Mobile, valores);
            Assert.Contains(TipoDispositivo.Tablet, valores);
            Assert.Contains(TipoDispositivo.Web, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(TipoDispositivo.NaoCadastrado, (TipoDispositivo)0);
            Assert.Equal(TipoDispositivo.Mobile, (TipoDispositivo)1);
            Assert.Equal(TipoDispositivo.Tablet, (TipoDispositivo)2);
            Assert.Equal(TipoDispositivo.Web, (TipoDispositivo)3);
        }
    }
}