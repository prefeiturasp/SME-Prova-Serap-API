using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class TipoTurnoTest
    {
        [Fact]
        public void Deve_Conter_Membro_Manha_Com_Valor_1()
        {
            Assert.Equal(1, (int)TipoTurno.Manha);
        }

        [Fact]
        public void Deve_Conter_Membro_Intermediario_Com_Valor_2()
        {
            Assert.Equal(2, (int)TipoTurno.Intermediario);
        }

        [Fact]
        public void Deve_Conter_Membro_Tarde_Com_Valor_3()
        {
            Assert.Equal(3, (int)TipoTurno.Tarde);
        }

        [Fact]
        public void Deve_Conter_Membro_Vespertino_Com_Valor_4()
        {
            Assert.Equal(4, (int)TipoTurno.Vespertino);
        }

        [Fact]
        public void Deve_Conter_Membro_Noite_Com_Valor_5()
        {
            Assert.Equal(5, (int)TipoTurno.Noite);
        }

        [Fact]
        public void Deve_Conter_Membro_Integral_Com_Valor_6()
        {
            Assert.Equal(6, (int)TipoTurno.Integral);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Seis_Membros()
        {
            var valores = Enum.GetValues(typeof(TipoTurno));
            Assert.Equal(6, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (TipoTurno[])Enum.GetValues(typeof(TipoTurno));
            Assert.Contains(TipoTurno.Manha, valores);
            Assert.Contains(TipoTurno.Intermediario, valores);
            Assert.Contains(TipoTurno.Tarde, valores);
            Assert.Contains(TipoTurno.Vespertino, valores);
            Assert.Contains(TipoTurno.Noite, valores);
            Assert.Contains(TipoTurno.Integral, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(TipoTurno.Manha, (TipoTurno)1);
            Assert.Equal(TipoTurno.Intermediario, (TipoTurno)2);
            Assert.Equal(TipoTurno.Tarde, (TipoTurno)3);
            Assert.Equal(TipoTurno.Vespertino, (TipoTurno)4);
            Assert.Equal(TipoTurno.Noite, (TipoTurno)5);
            Assert.Equal(TipoTurno.Integral, (TipoTurno)6);
        }
    }
}