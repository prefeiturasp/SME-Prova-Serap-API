using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class FamiliaFonteTest
    {
        [Fact]
        public void Deve_Conter_Membro_Poppins_Com_Valor_1()
        {
            Assert.Equal(1, (int)FamiliaFonte.Poppins);
        }

        [Fact]
        public void Deve_Conter_Membro_OpenDyslexic_Com_Valor_2()
        {
            Assert.Equal(2, (int)FamiliaFonte.OpenDyslexic);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Dois_Membros()
        {
            var valores = Enum.GetValues(typeof(FamiliaFonte));
            Assert.Equal(2, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (FamiliaFonte[])Enum.GetValues(typeof(FamiliaFonte));
            Assert.Contains(FamiliaFonte.Poppins, valores);
            Assert.Contains(FamiliaFonte.OpenDyslexic, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(FamiliaFonte.Poppins, (FamiliaFonte)1);
            Assert.Equal(FamiliaFonte.OpenDyslexic, (FamiliaFonte)2);
        }

        [Fact]
        public void Poppins_Deve_Ser_Menor_Que_OpenDyslexic()
        {
            Assert.True(FamiliaFonte.Poppins < FamiliaFonte.OpenDyslexic);
        }

        [Fact]
        public void Nao_Deve_Conter_Valor_Zero_Como_Membro_Nomeado()
        {
            Assert.False(Enum.IsDefined(typeof(FamiliaFonte), 0));
        }
    }
}